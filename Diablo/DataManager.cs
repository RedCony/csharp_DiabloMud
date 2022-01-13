using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Diablo
{
    class DataManager
    {
        private static DataManager instance;
        private const string DATA_PATH = "./Datas";
        private Dictionary<int,ChaData> dicChaDatas;
        private Dictionary<int,WeaponData> dicWeaponDatas;
        private Dictionary<int,MonsterData> dicMonsterDatas;

        private DataManager()
        {
            this.dicChaDatas = new Dictionary<int,ChaData>();
            this.dicWeaponDatas = new Dictionary<int,WeaponData>();
            this.dicMonsterDatas = new Dictionary<int,MonsterData>();
        }

        public static DataManager GetInstance()
        {
            if (DataManager.instance == null)
            {
                DataManager.instance = new DataManager();
            }
            return DataManager.instance;
        }
        public void LoadAllDatas()
        {
            string path = string.Format("{0}/{1}", DATA_PATH,"character_data.json");
            string json = File.ReadAllText(path);
            this.dicChaDatas = JsonConvert.DeserializeObject<ChaData[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH,"weapon_data.json");
            json = File.ReadAllText(path);
            this.dicWeaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH,"monster_data.json");
            json = File.ReadAllText(path);
            this.dicMonsterDatas = JsonConvert.DeserializeObject<MonsterData[]>(json).ToDictionary(x => x.id);

            Console.WriteLine("모든 데이터를 로드 했습니다.");
            Console.WriteLine("케릭터 데이터 : {0}개", this.dicChaDatas.Count);
            Console.WriteLine("무기 데이터 : {0}개", this.dicWeaponDatas.Count);
            Console.WriteLine("몬스터 데이터 : {0}개", this.dicMonsterDatas.Count);
        }

        public ChaData[] GetChaDatas()
        {
            return this.dicChaDatas.Values.ToArray<ChaData>();
        }

        public WeaponData GetWeaponDatas(int id)
        {
            return this.dicWeaponDatas[dicChaDatas[id].defaultWeaponId];
        }

        public MonsterData[] GetMonsterDatas()
        {
            return this.dicMonsterDatas.Values.ToArray<MonsterData>();
        }
    }
}
