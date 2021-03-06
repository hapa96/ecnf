﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonAdminLib
{
    public class PersonRegister
    {
        private List<Person> personList;
        public IList<Person> Persons { get { return personList; } }

        public PersonRegister()
        {
            personList = new List<Person>();
            personList.Add(new Person("Pascal", "Hauser"));
            personList.Add(new Person("Katharina", "Luzi"));
            personList.Add(new Person("Romeo", "Mutter"));


        }

        //Indexers- Return Value Person. Usage --> personRegister[i].Firstname
        public Person this[int index]
        {
            get { return personList[index]; }
        }

        public int Count { 
            get
            {
                return personList.Count;
            } }

        
        public void Sort(Comparison<Person> comparison)
        {
            personList.Sort(comparison);
        }
        public void PrintPersons()
        {
            foreach (var p in Persons)
                Console.WriteLine($"{p.Surname}, {p.Firstname}");
        }

  
    }
}
    
