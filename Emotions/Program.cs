using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emotions
{
    //Если я неверно понял задание, напишите пожалуйста замечания, я переделаю...
    //по-хорошему, все надо было бы разбить по отдельным файлам, но Вы просили одним .cs файлом
    class Program
    {
        static void Main(string[] args)
        {
            Worry myWorries = new Worry(10, 10, 150, 120);

            myWorries.HeartAttackEvent += () => Console.WriteLine("Your worries could be possible cause of heartattack because " +
                "your heartbeat is too high");
            Console.WriteLine("Your worry level that was caused by excitement is {0}\nYour worry level  " +
                "that was caused by fear is {1}", myWorries.AddExcitement(), myWorries.AddFear());
            
            Console.ReadKey();
        }
    }
    public abstract class NoEmotions
    {
        public int _selfcontrol = 0;
        public int _concentration = 0;
        public int _nervousness = 0;
    }

    public interface INegative
    {
        double AddFear();
    }
    public interface IPositive
    {
        double AddExcitement();
    }

    class Worry : NoEmotions, INegative, IPositive
    {
        private double _heartBeat;
        public int Coordination { get; set; }
        public int SpeechLevel { get; set; }
        public double Heartbeat
        {
            get
            {
                return this._heartBeat;
            }
            set
            {
                if (value > 0)
                {
                    this._heartBeat = value;
                    if(this._heartBeat >= 150 && HeartAttackEvent!=null)
                    {
                        HeartAttackEvent();
                        if (HeartAttackEvent != null)
                        {
                            HeartAttackEvent = null;
                        }
                    }
                }
            }
        }
        public double BloodPressure { get; set; }

        public Worry(int coordination, int speechLevel, int heartbeat, int bloodPressure)
        {
            this.Coordination = coordination;
            this.SpeechLevel = speechLevel;
            this.Heartbeat = heartbeat;
            this.BloodPressure = bloodPressure;
        }
                           
        public double AddFear ()
        {
            _selfcontrol += 4;
            _concentration -= 2;
            _nervousness += 5;
            Coordination -= 1;
            SpeechLevel -= 1;
            Heartbeat *= 1.2;
            BloodPressure *= 1.2;
            double _fWorryLevel = _selfcontrol + _concentration + _nervousness + Coordination + 
                SpeechLevel + Heartbeat + BloodPressure;
            return _fWorryLevel;
        }

        public double AddExcitement()
        {
            _selfcontrol += 2;
            _concentration += 2;
            _nervousness += 3;
            Coordination += 1;
            SpeechLevel -= 1;
            Heartbeat *= 1.3;
            BloodPressure *= 1.3;
            double _eWorryLevel = _selfcontrol + _concentration + _nervousness + Coordination +
                SpeechLevel + Heartbeat + BloodPressure;
            return _eWorryLevel;
        }

        public delegate void HeartAttackDel();
        public event HeartAttackDel HeartAttackEvent;
    }
}
