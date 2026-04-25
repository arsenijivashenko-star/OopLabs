using System;

namespace Lab6
{
    // Власні винятки (Завдання 4)
    public class NoInternetException : Exception
    {
        public NoInternetException(string message) : base(message) { }
    }

    public class BoringContentException : Exception
    {
        public BoringContentException(string message) : base(message) { }
    }

    // Апаратні компоненти
    public class Microcomputer
    {
        public void ProcessData() => Console.WriteLine("[Hardware] Мікрокомп'ютер обробляє потік даних...");
    }

    public class NetworkModule
    {
        public bool IsConnected { get; set; } = true;
        public string Type { get; private set; } // Wi-Fi або Bluetooth

        public NetworkModule(string type)
        {
            Type = type;
        }
    }

    public class VisualDevice
    {
        public void StreamToSmartTV(string visualData) =>
            Console.WriteLine($"[AR/VR Module] Трансляція на Smart TV: {visualData}");
    }
}