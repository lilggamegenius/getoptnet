﻿using System;
namespace NMaier.GetOptNet
{
    public enum ArgumentCollision
    {
        Overwrite,
        Ignore,
        Throw
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class Argument : Attribute
    {
        private string arg = "";
        private string helptext;
        private ArgumentCollision collision = ArgumentCollision.Ignore;


        public Argument() { }
        public Argument(string aArg) { arg = aArg; }
        public string GetArg() { return arg; }
        public string Helptext
        {
            get { return helptext; }
            set { helptext = value; }
        }
        public ArgumentCollision OnCollision
        {
            get { return collision; }
            set { collision = value; }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class ShortArgument : Attribute
    {
        private char arg;
        public ShortArgument(char aArg) { arg = aArg; }
        public char GetArg() { return arg; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class ArgumentAlias : Attribute
    {
        private string alias;
        public ArgumentAlias(string aAlias) { alias = aAlias; }
        public string GetAlias() { return alias; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class Counted : Attribute { }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class Parameters : Attribute { }


    [FlagsAttribute]
    public enum ArgumentPrefixType : ushort
    {
        None = 0,
        Dashes = 1,
        Slashes = 2,
        Both = 3
    }

    public enum UnknownArgumentsAction
    {
        IGNORE,
        THROW
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GetOptOptions : Attribute
    {
        private ArgumentPrefixType apt = ArgumentPrefixType.Both;
        private UnknownArgumentsAction uaa = UnknownArgumentsAction.IGNORE;

        public GetOptOptions() { }
        public ArgumentPrefixType AcceptPrefix
        {
            get { return apt; }
            set { apt = value; }
        }
        public UnknownArgumentsAction OnUnknownArgument
        {
            get { return uaa; }
            set { uaa = value; }
        }
    }
}