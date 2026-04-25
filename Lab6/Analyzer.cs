using System;

namespace Lab6
{
    public class Analyzer
    {
        public int DetermineKnowledgeLevel(string studentId)
        {
            Console.WriteLine($"[Analyzer] Збір метрик активності студента {studentId}...");
            // Симуляція оцінки рівня (від 1 до 100)
            return new Random().Next(40, 100);
        }

        public void AnalyzeMotivation()
        {
            Console.WriteLine("[Analyzer] Аналіз інтересів: Студент надає перевагу низькорівневій оптимізації та ручному керуванню пам'яттю.");
        }
    }
}