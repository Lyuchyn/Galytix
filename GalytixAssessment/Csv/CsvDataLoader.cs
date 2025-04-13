using CsvHelper;
using CsvHelper.Configuration;
using GalytixAssessment.Models;
using System.Globalization;

namespace GalytixAssessment.Csv
{
    public static class CsvDataLoader
    {
        public static GwpByCountryDataSet LoadCsv(string filePath)
        {
            var records = new List<GwpByCountry>();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<GwpByCountryMap>();
                records = csv.GetRecords<GwpByCountry>().ToList();
            }
            return new GwpByCountryDataSet { GwpRecords = records };
        }
    }

    public class GwpByCountryMap : ClassMap<GwpByCountry>
    {
        public GwpByCountryMap()
        {
            Map(m => m.Country).Name("country");
            Map(m => m.VariableId).Name("variableId");
            Map(m => m.VariableName).Name("variableName");
            Map(m => m.LineOfBusiness).Name("lineOfBusiness");
            Map(m => m.Y2000).Name("Y2000");
            Map(m => m.Y2001).Name("Y2001");
            Map(m => m.Y2002).Name("Y2002");
            Map(m => m.Y2003).Name("Y2003");
            Map(m => m.Y2004).Name("Y2004");
            Map(m => m.Y2005).Name("Y2005");
            Map(m => m.Y2006).Name("Y2006");
            Map(m => m.Y2007).Name("Y2007");
            Map(m => m.Y2008).Name("Y2008");
            Map(m => m.Y2009).Name("Y2009");
            Map(m => m.Y2010).Name("Y2010");
            Map(m => m.Y2011).Name("Y2011");
            Map(m => m.Y2012).Name("Y2012");
            Map(m => m.Y2013).Name("Y2013");
            Map(m => m.Y2014).Name("Y2014");
            Map(m => m.Y2015).Name("Y2015");
        }
    }
}
