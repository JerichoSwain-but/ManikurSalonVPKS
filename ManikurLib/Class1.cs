using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManikurLib
{
    public class DataBaseN
    {
     public bool AddDataToZapisTable(
     int IDZapis,
     int IDStud,
     int IDYslyga,
     string TimeZ,
     int IDMaster,
     string NameZakaz,
     string SecondNameZakaz,
     string OtchestvoZakaz
     )
        {
            ManikurSalon.Zapis zapis = new ManikurSalon.Zapis()
            {
                ID_Zapis = IDZapis,
                ID_stud = IDStud,
                ID_Yslyga = IDYslyga,
                Time = TimeZ,
                ID_Master = IDMaster,
                Name_Zakasik = NameZakaz,
                SecondName_Zakasik = SecondNameZakaz,
                Otchestvo_Zakasik = OtchestvoZakaz,
            };

            ManikurSalon.ManikurSalonEntities.GetContext().Zapis.Add(zapis);

            try
            {
                ManikurSalon.ManikurSalonEntities.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteDataFromYslygaTable(int yslyga_id)
        {
            var user = ManikurSalon.ManikurSalonEntities.GetContext().Yslyga.Where(p => p.ID_Yslyga == yslyga_id).FirstOrDefault();

            if (user != null)
            {
                ManikurSalon.ManikurSalonEntities.GetContext().Yslyga.Remove(user);

                try
                {
                    ManikurSalon.ManikurSalonEntities.GetContext().SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return false;
            }
        }

        public bool EditNameInMasterTable(
            int IDMaster,
            string NameM,
            string SecondNameM,
            string OtchestvoNameM
            )
        {
            var user = ManikurSalon.ManikurSalonEntities.GetContext().Masters.Where(p => p.ID_Masters == IDMaster).FirstOrDefault();

            if (user != null)
            {
                user.NameMaster = NameM;
                user.SecondNameMaster = SecondNameM;
                user.OtchestvoMaster = OtchestvoNameM;
                
                try
                {
                    ManikurSalon.ManikurSalonEntities.GetContext().SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return false;
            }
        }

        public ManikurSalon.Zapis GetUserZ_ID(int IDZ)
        {
            return ManikurSalon.ManikurSalonEntities.GetContext().Zapis.Where(p => p.ID_Zapis == IDZ).FirstOrDefault();
        }

        public ManikurSalon.Yslyga GetYslygaByID(int IDY)
        {
            return ManikurSalon.ManikurSalonEntities.GetContext().Yslyga.Where(p => p.ID_Yslyga == IDY).FirstOrDefault();
        }
    }
}
