using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_RazorWebPages
{
    public class RazorReferenzPageModel : PageModel
    {
        public string Username { get; set; }
        public Person[] People { get; set; }
        public void OnGet()
        {
            Username = "Max Mustermann";
            People = new Person[] { new Person("Max", 21), new Person("Sandra", 23), new Person("Andre", 41) };
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}