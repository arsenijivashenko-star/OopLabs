using System;

namespace Lab6
{
    public class SmartVoiceTutor : AdaptiveTextbook
    {
        private VisualDevice _vrDevice;

        public SmartVoiceTutor(string subject, NetworkModule network, Analyzer analyzer, Suggestion suggestion)
            : base(subject, network, analyzer, suggestion)
        {
            _vrDevice = new VisualDevice(); // Розширення функціоналу
        }

        // Метод пояснення теорії (Завдання 3)
        public void ExplainTheory(string topic)
        {
            TriggerNotification($"Голосовий тьютор починає пояснення теми: {topic}");
            _vrDevice.StreamToSmartTV($"Візуалізація архітектури для теми {topic}");
            _analyzer.AnalyzeMotivation();
        }

        public override void StartSession(string studentId)
        {
            base.StartSession(studentId);
            Console.WriteLine("[Smart Tutor] Активовано голосовий супровід та AR/VR модулі.");
        }

        // Симуляція критичної ситуації (Завдання 4)
        public void CheckContentEngagement(int engagementScore)
        {
            if (engagementScore < 30)
            {
                throw new BoringContentException("Поточний матеріал нецікавий для студента. Потрібна зміна парадигми навчання.");
            }
            Console.WriteLine("[Smart Tutor] Студент успішно засвоює матеріал.");
        }
    }
}