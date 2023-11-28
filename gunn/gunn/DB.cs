using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace gunn
{
    public class DB
    {
        public List<Guns> GetAllGun()
        {
            return new List<Guns>(App.DB.Guns).ToList();
        }

        public List<Ammos> GetAllAmmos()
        {
            return new List<Ammos>(App.DB.Ammos).ToList();
        }

        public List<Guns> GetGunPistol()
        {
            return new List<Guns>(App.DB.Guns.Where(s => s.Type == "Pistol").ToList());
        }

        public List<Guns> GetGunAssault()
        {
            return new List<Guns>(App.DB.Guns.Where(s => s.Type == "Assault").ToList());
        }

        public List<Ammos> GetAmmoPistol()
        {
            return new List<Ammos>(App.DB.Ammos.Where(s => s.Type == "PistolAmmo").ToList());
        }

        public List<Ammos> GetAmmoAssault()
        {
            return new List<Ammos>(App.DB.Ammos.Where(s => s.Type == "AssaultAmmo").ToList());
        }

        public Ammos FindAmmoId(int id)
        {
            return App.DB.Ammos.FirstOrDefault(ammo => ammo.Id == id);
        }
        public Guns FindGunsId(int id)
        {
            return App.DB.Guns.FirstOrDefault(gun => gun.Id == id);
        }

        public void AddGun(Guns guns)
        {
            App.DB.Guns.Add(guns);
            App.DB.SaveChanges();
        }

        public void AddAmmo(Ammos ammo)
        {
            App.DB.Ammos.Add(ammo);
            App.DB.SaveChanges();
        }

        public void RemoveGun(Guns guns)
        {
            App.DB.Guns.Remove(guns);
        }

        public void RemoveAmmo(Ammos ammos)
        {
            App.DB.Ammos.Remove(ammos);
        }
    }
}
