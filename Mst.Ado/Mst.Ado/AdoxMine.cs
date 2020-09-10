using System;
using ADOX;

namespace Mst.Ado
{
    public class AdoxMine
    {

        /// <summary>
        /// Girilen dosyayoluna mdb uzantılı access doyası oluşturan metot.
        /// </summary>
        /// <param name="MdbFilePath">Mdb dosyasının tamyolu ve dosyanın uzantılı ismi</param>
        /// <returns>
        /// 1: Dosya oluşturuldu.
        /// 0: Dosya zaten mevcut olduğundan oluşturulmadı.       
        /// </returns>
        public static Int32 createMDBFile(string MdbFilePath)
        {
            try
            {
                Int32 retInt = 0;
                CatalogClass Cat = new CatalogClass();
                Cat.Create(String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;
                   Data Source={0};
                   Jet OLEDB:Engine Type=5", MdbFilePath));
                retInt = 1;
                Cat = null;
                return retInt;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
    }
}
