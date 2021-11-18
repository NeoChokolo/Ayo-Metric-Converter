using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace MetricConverter.Ulitilities.Swagger
{
    public class CommentsFileHelper
    {
        public static string GenerateSwaggerFile()
        {
            XElement xml = null;

            foreach (string fileName in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.comments.xml"))
            {
                if (xml == null)
                {
                    xml = XElement.Load(fileName);
                }
                else
                {
                    XElement dependentXml = XElement.Load(fileName);
                    foreach (XElement ele in dependentXml.Descendants())
                    {
                        xml.Add(ele);
                    }
                }
            }

            //Save comments file

            string swaggerFile = AppContext.BaseDirectory + "\\CombinedDocumentation.xml";

            if (File.Exists(swaggerFile))
                File.Delete(swaggerFile);

            if (xml != null)
                xml.Save(swaggerFile);

            return swaggerFile;
        }
    }
}