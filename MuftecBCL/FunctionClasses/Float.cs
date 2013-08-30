using System;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Float
    {
        /// <summary>
        /// acos (f -- f)
        /// Returns the inverse cosine of a float.
        /// </summary>
        /// <example>
        /// 0.1 acos ( returns ) 1.470629...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("acos")]
        public static void Acosine(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Acos(item));
        }

        /// <summary>
        /// asin (f -- f)
        /// Returns the inverse sine of a float.
        /// </summary>
        /// <example>
        /// 0.1 asin ( returns ) 0.100167...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("asin")]
        public static void Asine(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Asin(item));
        }

        /// <summary>
        /// atan (f -- f)
        /// Returns the inverse tangent of a float.
        /// </summary>
        /// <example>
        /// 0.1 atan ( returns ) 0.0996687...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("atan")]
        public static void Atangent(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Atan(item));
        }

        /// <summary>
        /// atan2 (fy fx -- f)
        /// Returns the inverse tangent of (f1 / f2).
        /// </summary>
        /// <example>
        /// 5 2 atan2 ( returns ) 0.380506...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("atan2")]
        public static void Atangent2(OpCodeData data)
        {
            var fx = data.RuntimeStack.PopFloat();
            var fy = data.RuntimeStack.PopFloat();

            data.RuntimeStack.Push(System.Math.Atan2(fy, fx));
        }

        /// <summary>
        /// ceil (f -- f)
        /// Returns the next highest integer, as a floating point type.
        /// </summary>
        /// <example>
        /// 2.2 ceil ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("ceil")]
        public static void Ceiling(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Ceiling(item));
        }

        /// <summary>
        /// cos (f -- f)
        /// Returns the cosine of a float.
        /// </summary>
        /// <example>
        /// 0.1 cos ( returns ) 0.99500...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("cos")]
        public static void Cosine(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Cos(item));
        }

        /// <summary>
        /// diff3 (fx1 fy1 fx2 fy2 fz2 -- fx' fy' fz')
        /// Returns three floats, being the differences of fx1-fx2, fy1-fy2, and fz1-fz2.
        /// </summary>
        /// <example>
        /// 1 2 3 4 5 6 diff3 ( returns ) 3 3 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("diff3")]
        public static void Diff3(OpCodeData data)
        {
            var fz2 = data.RuntimeStack.PopFloat();
            var fy2 = data.RuntimeStack.PopFloat();
            var fx2 = data.RuntimeStack.PopFloat();
            var fz1 = data.RuntimeStack.PopFloat();
            var fy1 = data.RuntimeStack.PopFloat();
            var fx1 = data.RuntimeStack.PopFloat();

            data.RuntimeStack.Push(fx1 - fx2);
            data.RuntimeStack.Push(fy1 - fy2);
            data.RuntimeStack.Push(fz1 - fz2);
        }

        /// <summary>
        /// dist3d (fx fy fz -- f)
        /// Returns the distance of the XYZ coordinate from the origin.
        /// </summary>
        /// <example>
        /// 3 8 4 dist3d ( returns ) 9.433981...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("dist3d")]
        public static void Dist3D(OpCodeData data)
        {
            var fz = data.RuntimeStack.PopFloat();
            var fy = data.RuntimeStack.PopFloat();
            var fx = data.RuntimeStack.PopFloat();

            data.RuntimeStack.Push(System.Math.Sqrt(fx*fx + fy*fy + fz*fz));
        }

        /// <summary>
        /// epsilon ( -- f)
        /// Returns the smallest number such that 1.0 + Epsilon is distinct from 1.0.
        /// This is the error precision.
        /// </summary>
        /// <example>
        /// epsilon ( returns ) ... 4.940656...E-324
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("epsilon")]
        public static void Epsilon(OpCodeData data)
        {
            data.RuntimeStack.Push(Double.Epsilon);
        }

        /// <summary>
        /// exp (f -- f)
        /// Returns the value of e raised to the power of the passed float.
        /// </summary>
        /// <example>
        /// 2 exp ( returns ) 7.389056...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("exp")]
        public static void Exp(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Exp(item));
        }

        /// <summary>
        /// floor (f -- f)
        /// Returns the next lowest integer number, as a floating point type.
        /// </summary>
        /// <example>
        /// 2.7 floor ( returns ) 2.0
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("floor")]
        public static void Floor(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Floor(item));
        }

        /// <summary>
        /// fmod ( f1 f2 -- f )
        /// Returns the floating point remainder of f1 divided by f2.
        /// </summary>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("fmod")]
        public static void Fmod(OpCodeData data)
        {
            var f2 = data.RuntimeStack.PopFloat();
            var f1 = data.RuntimeStack.PopFloat();

            data.RuntimeStack.Push(System.Math.IEEERemainder(f1, f2));
        }

        /// <summary>
        /// frand ( -- f )
        /// Returns a random floating point number between 0 and 1.
        /// </summary>
        /// <example>
        /// frand ( returns ) 0.165436...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("frand")]
        public static void Frand(OpCodeData data)
        {
            if (data.RandomUnseeded == null)
                data.RandomUnseeded = new Random();

            data.RuntimeStack.Push(data.RandomUnseeded.NextDouble());
        }

        /// <summary>
        /// gaussian ( fs fm -- f )
        /// Given the standard deviation, and the mean, return a
        /// floating point random number with the given normalization.
        /// </summary>
        /// <example>
        /// 1 2 gaussian ( returns ) ?????
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("gaussian")]
        public static void Gaussian(OpCodeData data)
        {
            if (data.RandomUnseeded == null)
                data.RandomUnseeded = new Random();

            var fm = data.RuntimeStack.PopFloat();
            var fs = data.RuntimeStack.PopFloat();

            // Code taken from prim_gaussian from fbmuck
            // Box-Muller polar conversion
            var srca = 0d;
            var srcb = 0d;
            var radius = 1d;
            while (radius >= 1d)
            {
                srca = 2d*data.RandomUnseeded.NextDouble() - 1d;
                srcb = 2d*data.RandomUnseeded.NextDouble() - 1d;
                radius = srca*srca + srcb*srcb;
            }

            radius = System.Math.Sqrt((-2d*System.Math.Log(radius))/radius);
            var resulta = srca*radius;

            data.RuntimeStack.Push(fm + resulta * fs);
        }

        /// <summary>
        /// inf ( -- f )
        /// Returns the value of an Infinite result.
        /// </summary>
        /// <example>
        /// inf ( returns ) &#8734;
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("inf")]
        public static void Infinite(OpCodeData data)
        {
            data.RuntimeStack.Push(Double.PositiveInfinity);
        }

        /// <summary>
        /// log ( f -- f )
        /// Returns the natural log of float f.
        /// </summary>
        /// <example>
        /// 5 log ( returns ) 1.609437...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("log")]
        public static void Log(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Log(item));
        }

        /// <summary>
        /// log10 ( f -- f )
        /// Returns the log base 10 of float f.
        /// </summary>
        /// <example>
        /// 5 log10 ( returns ) 0.698970...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("log10")]
        public static void Log10(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Log10(item));
        }

        /// <summary>
        /// modf ( f -- fi ff )
        /// </summary>
        /// <example>
        /// 3.1415 modf ( returns ) 3.0 0.1415
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("modf")]
        public static void ModF(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            var fi = System.Math.Floor(item);
            var ff = item - fi;

            data.RuntimeStack.Push(fi);
            data.RuntimeStack.Push(ff);
        }

        /// <summary>
        /// pi ( -- f )
        /// Returns the value of Pi.
        /// </summary>
        /// <example>
        /// pi ( returns ) 3.1415...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("pi")]
        public static void Pi(OpCodeData data)
        {
            data.RuntimeStack.Push(System.Math.PI);
        }

        /// <summary>
        /// polar_to_xyz ( fr ft fp -- fx fy fz )
        /// Converts the spherical polar coordinate (fr, ft, fp) to the XYZ
        /// coordinate (fx, fy, fz). fr is the radius, ft is the theta, and fp is phi.
        /// </summary>
        /// <example>
        /// 
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("polar_to_xyz")]
        public static void PolarToXyz(OpCodeData data)
        {
            var phi = data.RuntimeStack.PopFloat();
            var theta = data.RuntimeStack.PopFloat();
            var radius = data.RuntimeStack.PopFloat();

            var x = (radius*System.Math.Cos(theta)*System.Math.Sin(phi));
            var y = (radius*System.Math.Sin(theta)*System.Math.Sin(phi));
            var z = (radius*System.Math.Cos(phi));

            data.RuntimeStack.Push(x);
            data.RuntimeStack.Push(y);
            data.RuntimeStack.Push(z);
        }

        /// <summary>
        /// round ( f i -- f )
        /// Round the floating point number to a given precision.
        /// </summary>
        /// <example>
        /// 7.899 1 round ( returns ) 7.9
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("round")]
        public static void Round(OpCodeData data)
        {
            var precision = data.RuntimeStack.PopInt();
            var value = data.RuntimeStack.PopFloat();

            data.RuntimeStack.Push(System.Math.Round(value, precision));
        }

        /// <summary>
        /// sin ( f -- f )
        /// Returns the sine of a float.
        /// </summary>
        /// <example>
        /// 0.1 sin ( returns ) 0.099833...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("sin")]
        public static void Sine(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Sin(item));
        }

        /// <summary>
        /// sqrt (float1 -- float2)
        /// Calculate the square root of a number, returned as a float.
        /// </summary>
        /// <example>
        /// 9 sqrt ( returns ) 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("sqrt")]
        public static void SquareRoot(OpCodeData data)
        {
            var item = Shared.Pop(data.RuntimeStack);

            if (item.IsNumber())
            {
                data.RuntimeStack.Push(System.Math.Sqrt(item.AsDouble()));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        /// <summary>
        /// tan ( f -- f )
        /// Returns the tangent of a float.
        /// </summary>
        /// <example>
        /// 0.1 tan ( returns ) 0.100335...
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        public static void Tangent(OpCodeData data)
        {
            var item = data.RuntimeStack.PopFloat();
            data.RuntimeStack.Push(System.Math.Tan(item));
        }

        /// <summary>
        /// xyz_to_polar ( fx fy fz -- fr ft fp )
        /// Converts the XYZ coordinate (fx, fy, fz) to the spherical polar
        /// coordinate (fr, ft, fp).
        /// </summary>
        /// <example>
        /// ????
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        public static void XyzToPolar(OpCodeData data)
        {
            var z = data.RuntimeStack.PopFloat();
            var y = data.RuntimeStack.PopFloat();
            var x = data.RuntimeStack.PopFloat();

            var dist = System.Math.Sqrt((x*x) + (y*y) + (z*z));
            var theta = 0d;
            var phi = 0d;

            if (dist > 0d)
            {
                theta = System.Math.Atan2(y, x);
                phi = System.Math.Acos(z/dist);
            }

            data.RuntimeStack.Push(dist);
            data.RuntimeStack.Push(theta);
            data.RuntimeStack.Push(phi);
        }
    }
}
