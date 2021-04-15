using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Home_Work_11
{
    class RandomWorkers
    {
        string[] firstnamesM = new string[] { "Иван", "Владислав", "Максим", "Дмитрий", "Алексей", "Игорь", "Александр", "Петр", "Константин", "Михаил", "Дамир", "Ильдар", "Тимофей", "Илья", "Руслан" };
        string[] firstnamesF = new string[] { "Жанна", "Дарья", "Ксения", "Кира", "Кристина", "Алла", "Мария", "Оксана", "Яна", "Валерия", "Вероника", "Елена", "Полина", "Любовь" };
        string[] lastnamesM = new string[] { "Иванов", "Петров", "Сидоров", "Трифонов", "Маслов", "Навозов", "Трудов", "Яснов", "Поленьев", "Валенков", "Серов", "Патапов", "Дятлов" };
        string[] lastnamesF = new string[] { "Иванова", "Петрова", "Сидорова", "Трифонова", "Маслова", "Навозова", "Трудова", "Яснова", "Поленьева", "Валенкова", "Серова", "Патапова", "Дятлова" };
        string[] sex = new string[] { "Male", "Female" };
        Random r = new Random();

        /// <summary>
        /// Случайно заполняет сотрудниками базу данных
        /// </summary>
        /// <param name="numWorkers">Кол-во работников</param>
        /// <param name="numS1">Максимальное кол-во работников в одном департаменте</param>
        /// <param name="numS2">Максимальное кол-во департаментов возглавляемых
        /// одним администратором</param>
        public RandomWorkers (int numWorkers, int numS1, int numS2)
        {
            int count = 0;
            for (int i = 0; i < numWorkers; i++)
            {
                string sexi = sex[r.Next(0, sex.Length)];
                string firstname;
                string lastname;
                if (sexi == "Male")
                {
                    firstname = firstnamesM[r.Next(0, firstnamesM.Length)];
                    lastname = lastnamesM[r.Next(0, lastnamesM.Length)];
                }
                else
                {
                    firstname = firstnamesF[r.Next(0, firstnamesF.Length)];
                    lastname = lastnamesF[r.Next(0, lastnamesF.Length)];
                }
                if (i % numS1 == 0) count ++;
                if (i % 10 == 0)
                {
                    DBWorkers.dbWorkers.Add(new Intern($"{firstname}", $"{lastname}",
                    r.Next(18, 25), $"Департамент: {count}"));
                }
                else DBWorkers.dbWorkers.Add(new Worker($"{firstname}", $"{lastname}",
                    r.Next(20, 51), $"Департамент: {count}"));
            }

            count = 1;
            int count2 = 0;
            for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
            {
                bool chek = false;
                if (DBWorkers.dbManagers.Count > 0)
                {
                    for (int j = 0; j < DBWorkers.dbManagers.Count; j++)
                    {
                        if (DBWorkers.dbWorkers[i].depart ==
                            DBWorkers.dbManagers[j].depart)
                        {
                            chek = true;
                            break;
                        }
                    }
                }
                if (chek == false)
                {
                    string sexi = sex[r.Next(0, sex.Length)];
                    string firstname;
                    string lastname;
                    if (sexi == "Male")
                    {
                        firstname = firstnamesM[r.Next(0, firstnamesM.Length)];
                        lastname = lastnamesM[r.Next(0, lastnamesM.Length)];
                    }
                    else
                    {
                        firstname = firstnamesF[r.Next(0, firstnamesF.Length)];
                        lastname = lastnamesF[r.Next(0, lastnamesF.Length)];
                    }
                    DBWorkers.dbManagers.Add(new Manager($"{firstname}",
                        $"{lastname}", r.Next(25, 51),
                        DBWorkers.dbWorkers[i].depart, $"Главный департамент: {count}"));
                    count2++;
                    if (count2 == numS2)
                    {
                        count++;
                        count2 = 0;
                    }
                }
            }

            CreateAdmin(0, DBWorkers.dbManagers.Count - 1, numS2);
        }

        private void CreateAdmin (int indexA, int indexB, int num)
        {
            ObservableCollection<Manager> createDB = new ObservableCollection<Manager>();
            int count2 = 0;
            int count = 1;
            for (int i = indexA; i <= indexB; i++)
            {
                createDB.Add(DBWorkers.dbManagers[i]);
            }
            string nameMainDepart = $"{createDB[0].mainDepart}";
            double countNewAdminDouble = Math.Ceiling((double)createDB.Count / (double)num);

            int countNewAdmin = Convert.ToInt32(countNewAdminDouble);
            if (createDB.Count > num)
            {
                for (int i = 0; i < countNewAdmin; i++)
                {
                    string sexi = sex[r.Next(0, sex.Length)];
                    string firstname;
                    string lastname;
                    if (sexi == "Male")
                    {
                        firstname = firstnamesM[r.Next(0, firstnamesM.Length)];
                        lastname = lastnamesM[r.Next(0, lastnamesM.Length)];
                    }
                    else
                    {
                        firstname = firstnamesF[r.Next(0, firstnamesF.Length)];
                        lastname = lastnamesF[r.Next(0, lastnamesF.Length)];
                    }
                    DBWorkers.dbManagers.Add(new Administrator
                        ($"{firstname}", 
                        $"{lastname}", r.Next(25, 51),
                        $"{createDB[i * num].mainDepart}",
                        $"{nameMainDepart}_{count}"));
                    count2++;
                    if (count2 == num)
                    {
                        nameMainDepart = $"{createDB[count * num].mainDepart}";
                        count++;
                        count2 = 0;
                    }
                }
                CreateAdmin(DBWorkers.dbManagers.Count - countNewAdmin, DBWorkers.dbManagers.Count - 1, num);
            }
            else
            {
                for (int i = 0; i < countNewAdmin; i++)
                {
                    DBWorkers.dbManagers.Add(new Administrator
                        ($"Босс",
                        $"Боссович", 100,
                        $"{createDB[i * num].mainDepart}",
                        $"Главная организация"));
                }
            }
        }
    }
}
