using DemoMultiCategories.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoMultiCategories.Models.Global.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Category ToCategory(this IDataRecord dataRecord)
        {
            return new Category() { Id = (int)dataRecord["Id"], Name = (string)dataRecord["Name"] };
        }

        internal static Movie ToMovie(this IDataRecord dataRecord)
        {
            return new Movie() { Id = (int)dataRecord["Id"], Title = (string)dataRecord["Title"], Year = (int)dataRecord["Year"] };
        }
    }
}
