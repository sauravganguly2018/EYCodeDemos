﻿namespace IDELangDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LangC c = new LangC();
            LangCS cs = new LangCS();
            LangJava java = new LangJava();
            VBNet vb = new VBNet();

            //ide.CS =cs;
            //ide.C = c;
            //ide.Java = java;

            ide.Languages.Add(c);
            ide.Languages.Add(cs);
            ide.Languages.Add(java);
            ide.Languages.Add(vb);
            ide.DoWork();
        }
    }

    class IDE  // OCP
    {
        //public LangC C { get; set; }    
        //public LangJava Java { get; set; }  
        //public LangCS CS { get; set; }  
        public List<ILanguage> Languages = new List<ILanguage>();

        public void DoWork()
        {
            foreach (ILanguage l in Languages)
            {
                Console.WriteLine(l.GetName());
                Console.WriteLine(l.GetUnit());
                Console.WriteLine(l.GetParadigm());
                Console.WriteLine("______________");
            }
            
        }
    }

    interface ILanguage
    {
        public string GetName();
        public string GetUnit();
        public string GetParadigm();

    }

    abstract class OOLanguage : ILanguage
    {
        abstract public string GetName();
      
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object Oriented";
        }
    }

    abstract class ProcLanguage : ILanguage
    {
        abstract public string GetName();

        public string GetUnit()
        {
            return "Functions";
        }
        public string GetParadigm()
        {
            return "Procedural";
        }
    }

    class LangC: ProcLanguage
    {
        public override string GetName()
        {
            return "Lang C";
        }
    }

    class LangJava:OOLanguage
    {
        public override string GetName()
        {
            return "Lang Java";
        }
    }

    class LangCS : OOLanguage
    {
        public override string GetName()
        {
            return "Lang CS";
        }
    }

    class VBNet : OOLanguage
    {
        public override string GetName()
        {
            return "VB.Net";
        }
    }

}