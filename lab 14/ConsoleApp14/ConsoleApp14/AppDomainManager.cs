using System;
using System.Reflection;
using System.Runtime.Loader;

namespace ConsoleApp14
{
    public static class AppDomainManager
    {
        public static void ManipulateAppDomain()
        {
            Console.WriteLine($"Имя текущего домена: {AppDomain.CurrentDomain.FriendlyName}");
            Console.WriteLine("Загруженные сборки в текущий домен:");
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine($"- {asm.FullName}");
            }

            Console.WriteLine("Создаем новый контекст загрузки сборок");
            var context = new AssemblyLoadContext("NewContext", isCollectible: true);

            try
            {
                Console.WriteLine("Загружаем сборку System.Text.Json...");
                var assembly = context.LoadFromAssemblyName(new AssemblyName("System.Text.Json"));
                Console.WriteLine($"Сборка {assembly.FullName} успешно загружена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сборки: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Выгружаем контекст загрузки");
                context.Unload();
                Console.WriteLine("Контекст загрузки успешно выгружен");
            }
        }
    }
}
