using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus
{
    public class ClassBuilder
    {
        private readonly List<string> classes = new();

        public ClassBuilder Add(string? className)
        {
            if (className != null)
            {
                classes.Add(className);
            }
            return this;
        }

        public ClassBuilder AddIf(bool condition, string? className)
        {
            if (condition)
            {
                Add(className);
            }
            return this;
        }

        public ClassBuilder AddIfElse(bool condition, string? className, string? elseClassName)
        {
            if (condition)
            {
                Add(className);
            }
            else
            {
                Add(elseClassName);
            }
            return this;
        }

        public ClassBuilder AddIf(bool condition, Func<string?> className)
        {
            if (condition)
            {
                Add(className());
            }
            return this;
        }

        public ClassBuilder AddIfElse(bool condition, Func<string?> className, Func<string?> elseClassName)
        {
            if (condition)
            {
                Add(className());
            }
            else
            {
                Add(elseClassName());
            }
            return this;
        }

        public ClassBuilder AddIf(bool condition, Func<string?> className, string? elseClassName)
        {
            if (condition)
            {
                Add(className());
            }
            else
            {
                Add(elseClassName);
            }
            return this;
        }

        public ClassBuilder AddIfElse(bool condition, Func<string?> className, string? elseClassName)
        {
            if (condition)
            {
                Add(className());
            }
            else
            {
                Add(elseClassName);
            }
            return this;
        }

        public ClassBuilder AddIf(bool condition, string? className, Func<string?> elseClassName)
        {
            if (condition)
            {
                Add(className);
            }
            else
            {
                Add(elseClassName());
            }
            return this;
        }

        public ClassBuilder AddIfElse(bool condition, string? className, Func<string?> elseClassName)
        {
            if (condition)
            {
                Add(className);
            }
            else
            {
                Add(elseClassName());
            }
            return this;
        }

        public ClassBuilder AddIf(bool condition, Func<string?> className, Func<string?> elseClassName)
        {
            if (condition)
            {
                Add(className());
            }
            else
            {
                Add(elseClassName());
            }
            return this;
        }

        public ClassBuilder AddAll(IEnumerable<string?> classNames)
        {
            foreach (var className in classNames)
            {
                Add(className);
            }
            return this;
        }

        public string Build()
        {
            return string.Join(" ", classes);
        }
    }
}
