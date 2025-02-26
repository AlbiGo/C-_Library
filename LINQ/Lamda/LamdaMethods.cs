using DataManagement.DbContext;
using DataManagement.Entities;

namespace LINQ.Lamda
{
    // Class containing methods for performing various Lambda queries on Entity1 data.
    public class LamdaMethods
    {
        // Private field for accessing the database context.
        private readonly DatabaseContext _dbContext;

        // Constructor that initializes the database context.
        public LamdaMethods()
        {
            _dbContext = new DatabaseContext();
        }

        // Method to get all records from Entity1 without any filtering or pagination.
        public IQueryable<Entity1> GetAll()
        {
            // Return all records of Entity1 as an IQueryable to allow further querying.
            return _dbContext.Entity1s
                .AsQueryable();
        }

        // Method to get records from Entity1 with pagination support.
        // page: Current page (default is 1), size: Number of records per page (default is 10).
        public IQueryable<Entity1> GetAllPagination(int page = 1, int size = 10)
        {
            // Apply Skip (for pagination) and Take (to limit the number of records).
            return _dbContext.Entity1s
                .Skip((page - 1) * size)  // Corrected page index for 0-based pagination.
                .Take(size)               // Take the specified number of records.
                .AsQueryable();
        }

        // Method to filter records based on the provided entity filter.
        // entityFilter: Contains the criteria for filtering records (e.g., Name, page, and size).
        public IQueryable<Entity1> GetWhere(EntityFilter entityFilter)
        {
            // Start with the Entity1 table as the base query.
            var query = _dbContext.Entity1s
                .AsQueryable();

            // Apply a filter for the Name field if it's not empty.
            if (entityFilter.Name != string.Empty)
            {
                query = query.Where(p => p.Name.Contains(entityFilter.Name));
            }

            // Apply pagination to the query based on the filter's page and size values.
            return query.Skip(entityFilter.Page)   // Skip records based on page.
                .Take(entityFilter.Size);           // Take the number of records defined by size.
        }

        // Method to join Entity1 with Entity2 and select specific fields to return. This performs a
        // LINQ join operation between Entity1 and Entity2 on their ID fields.
        public IQueryable<Entity1WithRelationshipDTO> GetJoin()
        {
            // Perform the join between Entity1 and Entity2 based on matching Entity2ID and Id fields.
            var query = _dbContext.Entity1s.Join(_dbContext.Entity2s,
                x => x.Entity2ID, // Key from Entity1.
                y => y.Id,        // Key from Entity2.
                (x, y) => (x))    // Select Entity1, joined with matching Entity2.
                .Select(x => new Entity1WithRelationshipDTO
                {
                    Entity1Name = x.Name,            // Project Name from Entity1.
                    ID = x.Id,                       // Project ID from Entity1.
                    Entity2Name = x.Entity2.Name     // Project Name from related Entity2.
                });

            // Return the result of the join operation as a queryable.
            return query;
        }

        // Method to join Entity1 with Entity2 and select specific fields to return wtih filter.
        // This performs a LINQ join operation between Entity1 and Entity2 on their ID fields.
        public IQueryable<Entity1WithRelationshipDTO> GetJoinWithFilter(EntityFilter entityFilter)
        {
            var query = _dbContext.Entity1s
                .AsQueryable();

            //Filtering
            if (entityFilter.Name != null)
            {
                query = query.Where(p => p.Name.Contains(entityFilter.Name));
            }

            // Perform the join between Entity1 and Entity2 based on matching Entity2ID and Id fields.
            var result = query.Join(_dbContext.Entity2s,
                x => x.Entity2ID, // Key from Entity1.
                y => y.Id,        // Key from Entity2.
                (x, y) => (x))    // Select Entity1, joined with matching Entity2.
                .Select(x => new Entity1WithRelationshipDTO
                {
                    Entity1Name = x.Name,            // Project Name from Entity1.
                    ID = x.Id,                       // Project ID from Entity1.
                    Entity2Name = x.Entity2.Name     // Project Name from related Entity2.
                })
                .Skip(entityFilter.Page)
                .Take(entityFilter.Size);

            // Return the filtered result of the join operation as a queryable.
            return result;
        }
    }

    // DTO class for transferring data between Entity1 and Entity2 in a joined result.
    public class Entity1WithRelationshipDTO
    {
        public int ID { get; set; }          // ID of Entity1.
        public string Entity1Name { get; set; }  // Name from Entity1.
        public string Entity2Name { get; set; }  // Name from related Entity2.
    }

    // Filter class used to pass filtering and pagination options.
    public class EntityFilter
    {
        public string Name { get; set; }  // Name filter for searching entities.
        public int Page { get; set; }     // Page number for pagination.
        public int Size { get; set; }     // Number of records per page for pagination.
    }
}