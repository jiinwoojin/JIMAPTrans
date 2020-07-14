using JIMapTrans.Options;
using OSGeo.GDAL;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace JIMapTrans.GdalConfig
{
    public class GdalConfigManager
    {

        public static void Initialize()
        {
            GdalConfiguration.ConfigureGdal();

            //gdaladdo -ro -r average --config BIGTIFF_OVERVIEW IF_SAFER --config COMPRESS_OVERVIEW JPEG {orthophoto} 2 4 8 16 > {log}

            //Gdal.SetConfigOption("CPL_DEBUG", "ON");
            Gdal.SetConfigOption("BIGTIFF_OVERVIEW", "IF_SAFER");
            //Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            
            SetGdalCacheMaxValue(4000);
        }

        public static string[] GdalCommandLineParsing(string commandString)
        {
            return Gdal.ParseCommandLine(commandString);
        }

        public static void SetGdalCacheMaxValue(uint maxValue)
        {
            //Gdal.SetCacheMax(maxValue);
            Gdal.SetConfigOption("GDAL_CACHEMAX", maxValue.ToString());
        }

        public static void SetGdalSwatchSizeValue(uint swatchSize)
        {
            Gdal.SetConfigOption("GDAL_SWATH_SIZE", swatchSize.ToString());
        }

        public static CreationOptionList GetCreationOptionListFromXml()
        {
            CreationOptionList optionList;
            Driver d = Gdal.GetDriverByName("GTiff");
            string xmlString = d.GetMetadataItem("DMD_CREATIONOPTIONLIST", "");

            //XMLNode node = Gdal.ParseXMLString(xmlString);

            var serializer = new XmlSerializer(typeof(CreationOptionList));
            using (var reader = new StringReader(xmlString))
            {
                optionList = (CreationOptionList)serializer.Deserialize(reader);
            }

            return optionList;
        }

        public static List<GdalRasterFileFormat> GetGdalRasterFileFormats()
        {
            List<GdalRasterFileFormat> fileFormats = new List<GdalRasterFileFormat>();

            int count = Gdal.GetDriverCount();
            for (int i = 0; i < count; i++)
            {
                Driver d = Gdal.GetDriver(i);

                string longName = d.GetMetadataItem("DMD_LONGNAME", "");
                string extensions = d.GetMetadataItem("DMD_EXTENSIONS", "");
                string raster = d.GetMetadataItem("DCAP_RASTER", "");

                if (raster == null)
                {
                    continue;
                }
                if (raster != "YES")
                {
                    continue;
                }

                if (extensions == null)
                {
                    continue;
                }

                if (extensions == "")
                {
                    continue;
                }

                extensions = extensions.Replace(".", "");

                string ext = extensions.Replace(" ", " *.");

                fileFormats.Add(new GdalRasterFileFormat(string.Format("{0} (*.{1})", longName, ext), extensions));
            }

            return fileFormats.OrderBy(x => x.LongName).Select(x => x).ToList();
        }


        public static string GetGdalRasterFormatFileFilterString()
        {
            string filterString = "";

            List<GdalRasterFileFormat> fileFormats = GetGdalRasterFileFormats();

            foreach (var format in fileFormats)
            {
                string ext = format.Extensions.Replace(" ", ";*.");
                filterString += string.Format("{0}|*.{1}|", format.LongName, ext);
            }

            filterString += "모든 파일 (*.*)|*.*";

            return filterString;
        }

        public static void SetProfileSetting(string optionString)
        {
            if (optionString.Length < 1)
            {
                return;
            }

            string[] options = optionString.Split(' ');

            if (options.Length < 1)
            {
                return;
            }

            foreach (var opt in options)
            {
                string[] option = opt.Split('=');

                if (option.Length != 2)
                {
                    continue;
                }
                Gdal.SetConfigOption(option[0], option[1]);
            }
        }

        public static void SetProfileSettingDefault(string optionString)
        {
            if (optionString.Length < 1)
            {
                return;
            }

            string[] options = optionString.Split(' ');

            if (options.Length < 1)
            {
                return;
            }

            foreach (var opt in options)
            {
                string[] option = opt.Split('=');

                if (option.Length != 2)
                {
                    continue;
                }
                Gdal.SetConfigOption(option[0], null);
            }

            Gdal.SetConfigOption("BIGTIFF_OVERVIEW", "IF_SAFER");
        }

    }
}
