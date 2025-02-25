using Microsoft.EntityFrameworkCore;

namespace AuditEntry
{
    // Represents the database context for handling audit entries and related entities
    public class AuditDbContext : DbContext
    {
        // Constructor for dependency injection with DbContextOptions
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }

        // Default constructor, useful for scenarios like in-memory databases
        public AuditDbContext()
        { }

        // DbSet properties represent tables in the database
        public DbSet<AuditEntry> AuditEntries { get; set; }

        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public DbSet<User> Users { get; set; }

        // Configures the database context, here using an in-memory database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Creates a unique in-memory database for each session
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }

        // Asynchronously saves changes to the database, including creating audit entries
        public virtual async Task<int> SaveChangesAsync(string userId = "141414")
        {
            // Prepare audit entries before saving changes
            OnBeforeSaveChanges(userId);
            // Save changes to the database and return the result
            return await base.SaveChangesAsync();
        }

        // Prepares audit entries by tracking changes before saving to the database
        private void OnBeforeSaveChanges(string userId)
        {
            // Detect changes made to the entities being tracked by the DbContext
            ChangeTracker.DetectChanges();

            // Filter out entries that shouldn't be audited and convert to a list
            var entries = ChangeTracker.Entries()
                .Where(entry => !(entry.Entity is AuditEntry) && entry.State != EntityState.Detached && entry.State != EntityState.Unchanged)
                .ToList();

            // Iterate over each entry to create audit entries and properties
            foreach (var entry in entries)
            {
                // Create a new audit entry for the current entity
                var auditEntry = CreateAuditEntry(entry, userId);

                // Add the audit entry to the AuditEntries DbSet
                AuditEntries.Add(auditEntry);

                // Create and add audit entry properties for each property in the entity
                foreach (var property in entry.Properties)
                {
                    // Create an audit entry property for the current property
                    var auditEntryProperty = CreateAuditEntryProperty(entry, property, auditEntry);
                    // Add the audit entry property to the AuditEntryProperties DbSet
                    AuditEntryProperties.Add(auditEntryProperty);
                }
            }
        }

        // Creates an audit entry for a given entity entry and user ID
        private AuditEntry CreateAuditEntry(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, string userId)
        {
            return new AuditEntry
            {
                EntityName = entry.Entity.GetType().Name, // Store the entity's name
                UserId = int.Parse(userId), // Associate the user ID with the audit entry
                Type = entry.State.ToString(), // Record the type of entity state change
                EntityID = GetEntityPrimaryKey(entry) // Get and store the primary key value
            };
        }

        // Retrieves the primary key value of an entity entry
        private int GetEntityPrimaryKey(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
        {
            // Attempt to find a property named 'Id' or 'ID' as the primary key
            var primaryKeyProperty = entry.Properties
                .FirstOrDefault(p => p.Metadata.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));

            // Throw an exception if no primary key is found
            if (primaryKeyProperty == null)
            {
                throw new InvalidOperationException("Entity does not have a primary key property named 'Id' or 'ID'.");
            }

            // Return the primary key value as an integer
            return Convert.ToInt32(primaryKeyProperty.CurrentValue);
        }

        // Creates an audit entry property for a given property entry and audit entry
        private AuditEntryProperty CreateAuditEntryProperty(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, Microsoft.EntityFrameworkCore.ChangeTracking.PropertyEntry property, AuditEntry auditEntry)
        {
            var auditEntryProperty = new AuditEntryProperty
            {
                PropertyName = property.Metadata.Name, // Record the property name
                AuditEntryID = auditEntry.ID, // Associate with the audit entry ID
                Modified = property.IsModified ? "Yes" : "No" // Indicate if the property was modified
            };

            // Determine the values to record based on the entity state
            switch (entry.State)
            {
                case EntityState.Added:
                    // Record the new value for added entities
                    auditEntryProperty.PropertyNewValue = property.CurrentValue?.ToString();
                    break;

                case EntityState.Deleted:
                    // Record the old value for deleted entities
                    auditEntryProperty.PropertyOldValue = property.OriginalValue?.ToString();
                    break;

                case EntityState.Modified:
                    // Record both old and new values for modified entities
                    if (property.IsModified)
                    {
                        auditEntryProperty.PropertyOldValue = property.OriginalValue?.ToString();
                        auditEntryProperty.PropertyNewValue = property.CurrentValue?.ToString();
                    }
                    break;
            }

            return auditEntryProperty;
        }
    }
}