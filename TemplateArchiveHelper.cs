using DPFP;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CND.Biometric.Fingerprint
{
    public static class TemplateArchiveHelper
    {

        public static bool SaveTemplateArchive(FingerprintTemplateCollection templates, string fileName)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var template in templates)
                        {
                            var demoFile = archive.CreateEntry(template.Identifier+".fpt");

                            using (var templateStream = demoFile.Open())
                            {
                                template.Template.Serialize(templateStream);
                            }
                        }
                    }

                    using (var fileStream = File.Open(fileName, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public static FingerprintTemplateCollection GetTemplates(String zipPath)
        {
            if (!File.Exists(zipPath))
                return new FingerprintTemplateCollection();

            var templates = new FingerprintTemplateCollection();
            try
            {
                string extractPath = System.IO.Path.GetTempPath()+"cnd-biometric";
                System.IO.Directory.CreateDirectory(extractPath);

                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        var identifier = Path.GetFileNameWithoutExtension(entry.FullName);
                        var tempPath = Path.Combine(extractPath, entry.FullName);
                        entry.ExtractToFile(tempPath,true);
                        using (FileStream fs = File.OpenRead(tempPath))
                        {
                            templates.Add(new FingerprintTemplate(identifier, new Template(fs)));
                        }
                    }
                }

                return templates;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}
