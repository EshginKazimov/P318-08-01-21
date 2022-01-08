using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DomainModel.Dto;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var request = await httpClient.GetAsync("https://localhost:44390/api/Students");
            var response = await request.Content.ReadAsStringAsync();

            var students = JsonConvert.DeserializeObject<List<StudentDto>>(response);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.Name} - {student.Surname}");
            }
        }
    }
}
