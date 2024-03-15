using System.Diagnostics.CodeAnalysis;

namespace Laboratorio1_CARG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salirSistema = false;
            while (!salirSistema)
            {
                Console.WriteLine(
                "----MENÚ DEL SISTEMA----" +
                "\n1- Año de nacimiento." +
                "\n2- Menú de ecuaciones." +
                "\n3- Coordenadas polares a rectangulares." +
                "\n4- Calcular progresión." +
                "\n5- Serie de Fibonacci." +
                "\n6- Serie de fracciones.\n" +
                "\n0- CERRAR EL SISTEMA.\n" +
                "\nIngrese la opcion que desea:");
                String entradaOpcion = Console.ReadLine();

                if (!int.TryParse(entradaOpcion, out int opcion))
                {
                    ErrorTipoDato();
                    continue;
                }

                switch (opcion)
                {
                    case 0:
                        salirSistema = true;
                        Console.WriteLine("\nNOSPIIII");
                        break;

                    case 1:
                        while (true)
                        {
                            Console.WriteLine("\nIngrese su año de nacimiento: ");
                            String entradaFechaNac = Console.ReadLine();

                            if (!int.TryParse(entradaFechaNac, out int fechaNac) || fechaNac < 0)
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            Console.WriteLine($"\nUsted tiene {Edad(fechaNac)} años\n");
                            break;
                        }
                        break;

                    case 2:
                        bool salirMenu = false;
                        while (!salirMenu)
                        {
                            Console.WriteLine(
                            "\n----MENÚ PUNTO 2----" +
                            "\na) Dividir." +
                            "\nb) Obtener cubo." +
                            "\nc) Calculo de IMC (Índice de Masa Corporal)." +
                            "\nd) Salir.\n" +

                            "\nIngrese la opcion que desea:");
                            String opcionMenuP2 = Console.ReadLine().ToUpper();

                            switch (opcionMenuP2)
                            {
                                case "A":
                                    Division();
                                    break;

                                case "B":
                                    Cubo();
                                    break;

                                case "C":
                                    IMC();
                                    break;

                                case "D":
                                    salirMenu = true;
                                    Console.WriteLine("\nDevuelta al menú principal ¯|_(O_O)_|¯\n");
                                    break;

                                default:
                                    ErrorTipoDato();
                                    continue;
                            }
                        }
                        break;

                    case 3:
                        while (true)
                        {
                            Console.WriteLine("\nRECUERDE INGRESAR LOS DECIMALES SEPARADOS POR UNA COMA");
                            Console.WriteLine("\nIngresa la magnitud (r):");
                            String entradaMagnitud = Console.ReadLine();

                            if (!double.TryParse(entradaMagnitud, out double magnitud))
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            Console.WriteLine("\nIngresa el ángulo en grados (θ):");
                            String entradaAngulo = Console.ReadLine();

                            if (!double.TryParse(entradaAngulo, out double anguloGrados))
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            double anguloRadianes = anguloGrados * Math.PI / 180.0;

                            ConvertirPolarRectangular(magnitud, anguloRadianes, out double x, out double y);

                            Console.WriteLine($"\nCoordenadas rectangulares: ({x.ToString("F2")}, {y.ToString("F2")})\n");
                            break;
                        }
                        break;

                    case 4:
                        while(true)
                        {
                            Console.WriteLine("\nIngrese el número que aparecerá en la secuencia (x): ");
                            String entradaSecuenciaX = Console.ReadLine();

                            if (!double.TryParse(entradaSecuenciaX, out double secuenciaX) || secuenciaX < 0)
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            Console.WriteLine("\nIngrese la cantidade de veces que aparecerá x (n): ");
                            String entradaSecuenciaN = Console.ReadLine();

                            if (!double.TryParse(entradaSecuenciaN, out double secuenciaN) || secuenciaN < 0)
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            CalcularProgresion(secuenciaX, secuenciaN);
                            break;
                        }
                        break;

                    case 5:
                        while (true)
                        {
                            Console.WriteLine("\nIngrese la cantidad de sucesiones que desea: ");
                            String entradaSucesiones = Console.ReadLine();

                            if (!int.TryParse(entradaSucesiones, out int sucesiones) || sucesiones < 1)
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            Fibonacci(sucesiones);
                            Console.WriteLine("\n");
                            break;
                        }
                        break;

                    case 6:
                        while (true)
                        {
                            Console.WriteLine("\nIngrese el valor de n: ");
                            String entradaFracciones = Console.ReadLine();

                            if(!int.TryParse(entradaFracciones, out int n) || n < 0)
                            {
                                ErrorTipoDato();
                                continue;
                            }

                            double resultado = Fracciones(n, out string serie);

                            Console.WriteLine($"\nLa serie es: {serie}");
                            Console.WriteLine($"El resultado de la serie es: {resultado}\n");
                            break;
                        }
                        break;

                    default:
                        Console.WriteLine("\nSELECCIONE UNA OPCIÓN VÁLIDA");
                        continue;

                }
            }
            Console.ReadKey();
        }

        static int Edad(int fechaNac)
        {
            DateTime fechaActual = DateTime.Now;
            int añoActual = fechaActual.Year;

            return añoActual - fechaNac;
        }

        static void Division()
        {
            while (true)
            {
                Console.WriteLine("\nRECUERDE INGRESAR LOS DECIMALES SEPARADOS POR UNA COMA");
                Console.WriteLine("\nIngrese el dividendo: ");
                String entradaDividendo = Console.ReadLine();

                if (!double.TryParse(entradaDividendo, out double dividendo) || dividendo < 0)
                {
                    ErrorTipoDato();
                    continue;
                }

                Console.WriteLine("\nIngrese el divisor: ");
                String entradaDivisor = Console.ReadLine();

                if (!double.TryParse(entradaDivisor, out double divisor) || divisor < 0)
                {
                    ErrorTipoDato();
                    continue;
                }

                Console.WriteLine($"\nEl resultado de {dividendo}/{divisor} es {(dividendo / divisor).ToString("F2")}");
                break;
            }
        }

        static void Cubo()
        {
            while (true)
            {
                Console.WriteLine("\nRECUERDE INGRESAR LOS DECIMALES SEPARADOS POR UNA COMA");
                Console.WriteLine("\nIngrese un número que requiera elevar al cubo (3): ");
                String entradaCubo = Console.ReadLine();

                if (!double.TryParse(entradaCubo, out double cubo) || cubo < 0)
                {
                    ErrorTipoDato();
                    continue;
                }

                Console.WriteLine($"\nEl resultado de {cubo}^3 es {Math.Pow(cubo, 3).ToString("F2")}");
                break;
            }
        }

        static void IMC()
        {
            while (true)
            {
                Console.WriteLine("\nRECUERDE INGRESAR LOS DECIMALES SEPARADOS POR UNA COMA");
                Console.WriteLine("\nIngrese su peso en kilogramos: ");
                String entradaPeso = Console.ReadLine();

                if (!double.TryParse(entradaPeso, out double peso) || peso < 0)
                {
                    ErrorTipoDato();
                    continue;
                }

                Console.WriteLine("\nIngrese su estatura en metros: ");
                String entradaEstatura = Console.ReadLine();

                if (!double.TryParse(entradaEstatura, out double estatura) || estatura < 0)
                {
                    ErrorTipoDato();
                    continue;
                }

                double imc = peso / (estatura * estatura);
                String estado = "";
                if (imc < 18.5)
                {
                    estado = "BAJO PESO o INSUFICIENTE";
                }
                else if (imc < 25)
                {
                    estado = "NORMAL";
                }
                else if (imc < 30)
                {
                    estado = "SOBREPESO";
                }
                else if (imc < 35)
                {
                    estado = "OBESIDAD TIPO I";
                }
                else if (imc < 40)
                {
                    estado = "OBESIDAD TIPO II";
                }
                else
                {
                    estado = "OBESIDAD TIPO III";
                }

                Console.WriteLine($"\nSu IMC es de {imc.ToString("F1")}. \nPara su salud, su estado es: {estado}");
                break;
            }
        }
        static void ConvertirPolarRectangular(double magnitud, double anguloRadianes, out double x, out double y)
        {
            x = magnitud * Math.Cos(anguloRadianes);
            y = magnitud * Math.Sin(anguloRadianes);
        }

        static void CalcularProgresion(double secuenciaX, double secuenciaN)
        {
            double resultadoSecuencia = 0;
            for (int secuencia = 1; secuencia <= secuenciaN; secuencia++)
            {
                if (secuencia == 1)
                {
                    resultadoSecuencia = secuenciaX + 1;
                }
                else
                {
                    resultadoSecuencia += secuenciaX;
                }
            }

            Console.WriteLine($"\nEl resultado de la secuencia 1 + {secuenciaX}(1) + ... + {secuenciaX}({secuenciaN}) = {resultadoSecuencia}\n");
        }

        static void Fibonacci(int sucesiones)
        {
            int fibonacci1 = 0;
            int fiboncci2 = 1;

            Console.Write($"\n{fibonacci1} ");

            for (int i = 0; i < sucesiones; i++)
            {
                int temp = fibonacci1;

                fibonacci1 = fiboncci2;

                fiboncci2 = temp + fibonacci1;

                Console.Write($"{fibonacci1} ");
            }
        }

        static double Fracciones(int n, out string serie)
        {
            double suma = 0;
            serie = "";

            for(int serieF = 1; serieF <= n; serieF++)
            {
                double termino = (double)serieF / Math.Pow(2, serieF);
                if(serieF % 2 == 0)
                {
                    termino *= -1;
                }
                suma += termino;

                serie += termino.ToString();
                if (serieF < n)
                    serie += " + ";
            }

            return suma;
        }

        static void ErrorTipoDato()
        {
            Console.WriteLine("\n¡Error! Entrada invalida");
        }
    }
}
