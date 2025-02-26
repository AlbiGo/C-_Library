using AdvancedFeatures.Generics.Implementation.Data;

namespace AdvancedFeatures.Generics.Implementation
{
    // Generic static class that operates on types implementing IMainData interface
    public static class GenericServices<T> where T : IMainData
    {
        // Asynchronous method to perform calculations on the data object of type T
        public static async Task Calculate(T data)
        {
            try
            {
                // Switch statement to handle different types that implement IMainData
                switch (data)
                {
                    // Case for handling Data1 type
                    case Data1:
                        // Cast data to Data1 type
                        var dataConvert = data as Data1;

                        // Perform calculations and update properties of Data1
                        dataConvert.Economics = 1 + 3;  // Simple calculation for Economics
                        dataConvert.MainEconimics = dataConvert.Economics * 22;  // MainEconimics based on Economics
                        break;

                    // Case for handling Data2 type
                    case Data2:
                        // Cast data to Data2 type
                        var dataConvert2 = data as Data2;

                        // Perform calculations and update properties of Data2
                        dataConvert2.Economic2 = 1 + 3;  // Simple calculation for Economic2
                        dataConvert2.MainEconimics = dataConvert2.Economic2 * 22;  // MainEconimics based on Economic2
                        break;

                    // Case for handling Data3 type
                    case Data3:
                        // Cast data to Data3 type
                        var dataConvert3 = data as Data3;

                        // Perform calculations and update properties of Data3
                        dataConvert3.Economics3 = 1 + 314;  // Simple calculation for Economics3
                        dataConvert3.MainEconimics = dataConvert3.Economics3 * 22;  // MainEconimics based on Economics3
                        break;
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during processing, but do nothing with the
                throw ex;
            }
        }
    }
}