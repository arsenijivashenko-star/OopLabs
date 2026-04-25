using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Створення зовнішніх залежностей
            NetworkModule wifiModule = new NetworkModule("Wi-Fi");
            Analyzer dataAnalyzer = new Analyzer();
            Suggestion aiSuggestion = new Suggestion();

            // 2. Ініціалізація головного об'єкта (похідного класу)
            SmartVoiceTutor tutor = new SmartVoiceTutor("Системна архітектура", wifiModule, dataAnalyzer, aiSuggestion);

            // 3. Підписка на події через делегати
            tutor.OnNotification += message =>
                Console.WriteLine($"\n[INFO] {message}");

            tutor.OnError += message =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[КРИТИЧНА ПОМИЛКА] {message}");
                Console.ResetColor();
            };

            // --- Тестування логіки ---
            Console.WriteLine("=== СЦЕНАРІЙ 1: Штатна робота ===");
            tutor.StartSession("Студент-ФІТ");
            tutor.ExplainTheory("Створення кросплатформної абстракції для I/O (Acorn)");

            Console.WriteLine("\n=== СЦЕНАРІЙ 2: Обробка винятку (Втрата мережі) ===");
            wifiModule.IsConnected = false; // Імітуємо відключення інтернету
            tutor.StartSession("Студент-ФІТ");

            Console.WriteLine("\n=== СЦЕНАРІЙ 3: Обробка винятку (Семантика предметної області) ===");
            try
            {
                // Імітуємо низьку залученість (студенту нудно)
                tutor.CheckContentEngagement(25);
            }
            catch (BoringContentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[ОБРОБКА ВИНЯТКУ] {ex.Message}");
                Console.WriteLine("-> Дія: Перемикання на практичні завдання зі складання ABuild...");
                Console.ResetColor();
            }

            Console.WriteLine("\nЗавершення роботи. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}