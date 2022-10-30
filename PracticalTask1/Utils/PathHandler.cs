using System;
using System.IO;

namespace PracticalTask1.Utils
{
    public static class PathHandler
    {
        /// <summary>
        /// Возвращает путь до файла вывода, который отрисовывает Grapviz
        /// </summary>
        /// <returns></returns>
        public static string GetPathOutput()
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @$"Static\Output");
            return combinedPath;
        }
        
        /// <summary>
        /// Получить путь до файла изображения
        /// </summary>
        /// <param name="name"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetPathImage(string name, string format="jpg")
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @$"Static\{name}.{format}");
            if (combinedPath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) == false)
            {
                combinedPath += ".jpg";
            }
            return combinedPath;
        }
        /// <summary>
        /// Возвращает путь до dot.exe
        /// </summary>
        /// <returns></returns>
        public static string GetPathDotExe()
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @$"ExternalLib\dot.exe");
            return combinedPath;
        }

        /// <summary>
        /// Возвращает путь до файла .dot графа
        /// </summary>
        /// <returns></returns>
        public static string GetGraphDotPath()
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @$"Static\GraphDot.dot");
            return combinedPath;
        }
        
        /// <summary>
        /// Возвращает путь до файла с данными (Json файл)
        /// </summary>
        /// <returns></returns>
        public static string GetDataPath()
        {
            var rootProject = GetRootProject();
            var combinedPath = Path.Combine(rootProject, @$"Static\data.json");
            return combinedPath;
        }
        
        private static string GetRootProject()
        {
            var path = Directory.GetCurrentDirectory();
            return Directory.GetParent(path)?.Parent?.Parent?.FullName;
        }
    }
}