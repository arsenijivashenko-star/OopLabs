using System;

namespace Lab6
{
    // Оголошення делегата для подій (Завдання 5)
    public delegate void TextbookEventHandler(string message);

    public class AdaptiveTextbook
    {
        // Події
        public event TextbookEventHandler OnError;
        public event TextbookEventHandler OnNotification;

        // Поля (Інкапсуляція)
        private Microcomputer _cpu;             // Композиція (жорсткий зв'язок)
        protected NetworkModule _network;       // Агрегація (може існувати окремо)
        protected Analyzer _analyzer;           // Асоціація
        protected Suggestion _suggestion;       // Асоціація

        public string Subject { get; set; }

        public AdaptiveTextbook(string subject, NetworkModule network, Analyzer analyzer, Suggestion suggestion)
        {
            Subject = subject;
            _cpu = new Microcomputer(); // Підручник не може існувати без процесора
            _network = network;         // Мережевий модуль може бути зовнішнім
            _analyzer = analyzer;
            _suggestion = suggestion;
        }

        // Відкритий метод моделювання роботи
        public virtual void StartSession(string studentId)
        {
            try
            {
                if (!_network.IsConnected)
                    throw new NoInternetException("Відсутній зв'язок із сервером. Перехід в офлайн-режим.");

                OnNotification?.Invoke($"Запуск сесії з предмету: {Subject}");
                _cpu.ProcessData();

                int level = _analyzer.DetermineKnowledgeLevel(studentId);
                string content = _suggestion.GetRecommendedContent(level);
                Console.WriteLine($"[Textbook] Адаптований матеріал: {content}");
            }
            catch (NoInternetException ex)
            {
                TriggerError(ex.Message);
            }
        }

        protected void TriggerError(string msg) => OnError?.Invoke(msg);
        protected void TriggerNotification(string msg) => OnNotification?.Invoke(msg);
    }
}