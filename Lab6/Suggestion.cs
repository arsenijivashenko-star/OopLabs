using System;

namespace Lab6
{
    public class Suggestion
    {
        public void GenerateEssay(string topic)
        {
            Console.WriteLine($"[Suggestion] Автоматична генерація реферату на тему: {topic}");
        }

        public string GetRecommendedContent(int knowledgeLevel)
        {
            if (knowledgeLevel < 50) return "Базовий синтаксис та стандартні колекції (STL / C# Collections)";
            return "Оптимізація " + "bare hardware" + " та кастомні алокатори пам'яті";
        }
    }
}