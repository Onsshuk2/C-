using System;

namespace pater2
{
    abstract class Processor
    {
        public string Name { get; set; }
        public Processor(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am a Processor. My name: {Name}");
        }
    }

    class AmdProcessor : Processor
    {
        public AmdProcessor(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am an AmdProcessor. My name: {Name}");
        }
    }

    class IntelProcessor : Processor
    {
        public IntelProcessor(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am an IntelProcessor. My name: {Name}");
        }
    }

    abstract class MainBoard
    {
        public string Name { get; set; }
        public MainBoard(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am a MainBoard. My name: {Name}");
        }
    }

    class AsusMainBoard : MainBoard
    {
        public AsusMainBoard(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am an AsusMainBoard. My name: {Name}");
        }
    }

    class MSIMainBoard : MainBoard
    {
        public MSIMainBoard(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am an MSIMainBoard. My name: {Name}");
        }
    }

    abstract class Box
    {
        public string Name { get; set; }
        public Box(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am a Box. My name: {Name}");
        }
    }

    class BlackBox : Box
    {
        public BlackBox(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am a BlackBox. My name: {Name}");
        }
    }

    class SilverBox : Box
    {
        public SilverBox(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am a SilverBox. My name: {Name}");
        }
    }

    abstract class Hdd
    {
        public string Name { get; set; }
        public Hdd(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am an Hdd. My name: {Name}");
        }
    }

    class LGHdd : Hdd
    {
        public LGHdd(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am an LGHdd. My name: {Name}");
        }
    }

    class SumsungHdd : Hdd
    {
        public SumsungHdd(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am a SumsungHdd. My name: {Name}");
        }
    }

    abstract class Memory
    {
        public string Name { get; set; }
        public Memory(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am a Memory. My name: {Name}");
        }
    }

    class DdrMemory : Memory
    {
        public DdrMemory(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am a DdrMemory. My name: {Name}");
        }
    }

    class Ddr2Memory : Memory
    {
        public Ddr2Memory(string name) : base(name) { }
        public override void Print()
        {
            Console.WriteLine($"I am a Ddr2Memory. My name: {Name}");
        }
    }

    interface IPcFactory
    {
        Box CreateBox();
        Processor CreateProcessor();
        MainBoard CreateMainBoard();
        Hdd CreateHdd();
        Memory CreateMemory();
    }

    class OfficePcFactory : IPcFactory
    {
        public Box CreateBox()
        {
            return new BlackBox("BlackBox");
        }

        public Hdd CreateHdd()
        {
            return new LGHdd("LGHdd");
        }

        public MainBoard CreateMainBoard()
        {
            return new AsusMainBoard("AsusMainBoard");
        }

        public Memory CreateMemory()
        {
            return new DdrMemory("DdrMemory");
        }

        public Processor CreateProcessor()
        {
            return new AmdProcessor("AmdProcessor");
        }
    }

    class HomePcFactory : IPcFactory
    {
        public Box CreateBox()
        {
            return new SilverBox("SilverBox");
        }

        public Hdd CreateHdd()
        {
            return new SumsungHdd("SumsungHdd");
        }

        public MainBoard CreateMainBoard()
        {
            return new MSIMainBoard("MSIMainBoard");
        }

        public Memory CreateMemory()
        {
            return new Ddr2Memory("Ddr2Memory");
        }

        public Processor CreateProcessor() => new IntelProcessor
("intelProcessor");
    }

    class Pc
    {
        public Box Box { get; set; }
        public Processor Processor { get; set; }
        public MainBoard MainBoard { get; set; }
        public Hdd Hdd { get; set; }
        public Memory Memory { get; set; }

        public void Print()
        {
            Box.Print();
            Processor.Print();
            MainBoard.Print();
            Hdd.Print();
            Memory.Print();
        }
    }

    class PcConfigurator
    {
        public Pc Pc { get; set; }
        public IPcFactory Factory { get; set; }
        public PcConfigurator(IPcFactory factory)
        {
            Factory = factory;
            Pc = new Pc();
        }

        public void Configure()
        {
            Pc.Box = Factory.CreateBox();
            Pc.Processor = Factory.CreateProcessor();
            Pc.MainBoard = Factory.CreateMainBoard();
            Pc.Hdd = Factory.CreateHdd();
            Pc.Memory = Factory.CreateMemory();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configure Office PC:");
            PcConfigurator officePcConfigurator = new PcConfigurator(new OfficePcFactory());
            officePcConfigurator.Configure();
            officePcConfigurator.Pc.Print();

            Console.WriteLine("\nConfigure Home PC:");
            PcConfigurator homePcConfigurator = new PcConfigurator(new HomePcFactory());
            homePcConfigurator.Configure();
            homePcConfigurator.Pc.Print();
        }
    }
}
