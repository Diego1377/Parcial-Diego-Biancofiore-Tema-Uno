using ArrayCubos.Entidades;

namespace ArrayObjetos.Entidades
{
    public class Cubo
    {

        private int _Arista;
        private TipodeBorde tipodeBorde;

        public TipodeBorde TipoDeBorde
        {
            get { return tipodeBorde; }
            set { tipodeBorde = value; }
        }

        private ColorRelleno colorRelleno;

        public ColorRelleno ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }
        public Cubo(int arista, TipodeBorde borde, ColorRelleno color)
        {
            _Arista = arista;
            TipoDeBorde = borde;
            ColorRelleno = color;
        }


        public Cubo()
        {

        }

        public int GetLado() => _Arista;

        public void SetLado(int arista)
        {
            if (arista > 0)
            {
                _Arista = arista;
            }
        }

        public object GetArea() => 6*Math.Pow(_Arista, 2);


        public object GetVolumen() =>Math.Pow(_Arista, 3);


    }
}