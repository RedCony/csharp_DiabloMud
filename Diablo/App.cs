using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class App
    {
        public enum eCharacterType
        {
            NONE,BARBARIAN,AMAZON,SOSURISE,PALADIN,MAX
        }
        public App()
        {
            DataManager.GetInstance().LoadAllDatas();

            Console.WriteLine("******************");
            Console.WriteLine("***** Diablo *****");
            Console.WriteLine("*** Game Start ***");
            Console.WriteLine("******************");


            ChaData[] characterDatas = DataManager.GetInstance().GetChaDatas();
            for (int i = 0; i < characterDatas.Length; i++)
            {
                var data = characterDatas[i];
                int idx = i + 1;
                Console.WriteLine("{0}.{1}", idx, data.name);
            }

            Console.Write("케릭터 선택해주세요(숫자1 ~4) : ");
            //string input = Console.ReadLine();
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                if (num <= characterDatas.Length)
                {
                    Console.WriteLine("입력한 수는 {0}입니다.", num);
                }
                else
                {
                    Console.WriteLine("잘못된 수를 입력하였습니다..");
                }
            }


            ChaData selectedChaData = characterDatas[num - 1];
            Console.WriteLine("어서오시게나 {0} 용사여...", selectedChaData.name);
            Console.WriteLine("무기를 주겠네...");
            eCharacterType characterType = (eCharacterType)num;


            WeaponData weaponData = DataManager.GetInstance().GetWeaponDatas(selectedChaData.id);  
            Weapon defaultWeapon = new Weapon(weaponData.id);

            
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(weaponData.name);
            Console.ResetColor();

            Console.Write("를 획득 했습니다.");
            Console.WriteLine();



            if (characterType == eCharacterType.PALADIN)
            {
                Console.WriteLine("헛!!!");
                Console.WriteLine("나 팔라딘인디.... -_-;;");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine("[목소리] 단검밖에 준비가 되지 않았네 미안하네...");
            }

            /*
            switch (characterType)
            {
                case eCharacterType.BARBARIAN:
                    Console.WriteLine("장검을 획득했습니다.");
                    break;
                case eCharacterType.AMAZON:
                    Console.WriteLine("활을 획득했습니다.");
                    break;
                case eCharacterType.PALADIN:
                    Console.WriteLine("단검을 획득했습니다.");
                    Console.WriteLine("헛!!!");
                    Console.WriteLine("나 팔라딘인디.... -_-;;");

                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    Console.WriteLine(".");

                    Console.WriteLine("[목소리] 단검밖에 준비가 되지 않았네 미안하네...");
                    break;
                case eCharacterType.SOSURISE:
                    Console.WriteLine("지팡이을 획득했습니다.");
                    break;
            }
            */
        }
    }
}
