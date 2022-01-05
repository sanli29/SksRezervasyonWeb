using SksRezervasyon.DataAccess.Abstract;
using SksRezervasyon.DataAccess.Repositories;
using SksRezervasyon.Core.Repository;
using SksRezervasyon.Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.DataAccess.Concretes
{
    public class OgrenciRepository : EFRepository<Ogrenci>, IOgrenciRepository, IDisposable
    {
        public OgrenciRepository(SksRezervasyonDbContext context) : base(context)
        {


        }
        public bool CheckEmail(string mail)
        {
            try
            {
                var result = Get(p => p.Email == mail);

                if (result == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Eposta kontrolünde hata çıktı", ex);
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

