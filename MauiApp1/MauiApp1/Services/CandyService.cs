using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class CandyService
    {
        private readonly List<Candy> _cukorkak;
        private readonly List<Listing> _eladasok;

        public CandyService(List<Candy> cukorkak, List<Listing> eladasok)
        {
            _cukorkak = cukorkak;
            _eladasok = eladasok;
        }

        public List<Candy> Osszes() => _cukorkak;

        public Candy KeresNevAlapjan(string nev) =>
            _cukorkak.FirstOrDefault(c =>
                c.Name.Equals(nev));

        public void Hozzaad(Candy uj)
        {
            if (_cukorkak.Any(c => c.Name.Equals(uj.Name)))
                throw new Exception("Ilyen nevű cukorka már létezik.");

            _cukorkak.Add(uj);
        }

        public void Frissit(string regiNev, string ujNev, double? ujAr, int? ujKeszlet)
        {
            var c = KeresNevAlapjan(regiNev);
            if (c == null) throw new Exception("Cukorka nem található.");

            if (!string.IsNullOrWhiteSpace(ujNev)) c.Name = ujNev;
            if (ujAr.HasValue) c.Price = ujAr.Value;
            if (ujKeszlet.HasValue) c.Quantity = ujKeszlet.Value;
        }

        public void Torol(string nev)
        {
            var c = KeresNevAlapjan(nev);
            if (c == null) throw new Exception("Cukorka nem található.");

            _cukorkak.Remove(c);
        }

        public void Eladas(string nev, int mennyiseg)
        {
            var c = KeresNevAlapjan(nev);
            if (c == null) throw new Exception("Cukorka nem található.");
            if (mennyiseg <= 0 || mennyiseg > c.Quantity)
                throw new Exception("Érvénytelen mennyiség.");

            c.Quantity -= mennyiseg;

            _eladasok.Add(new Listing
            {
                Name = c.Name,
                Quantity = mennyiseg,
                SalePrice = c.Price,
            });
        }
        public (string Nev, int Mennyiseg)? LegtobbetEladott()
        {
            if (_eladasok.Count == 0) return null;

            return _eladasok
                .GroupBy(e => e.Name, StringComparer.OrdinalIgnoreCase)
                .Select(g => (g.Key, g.Sum(x => x.Quantity)))
                .OrderByDescending(x => x.Item2)
                .First();
        }

        public List<Candy> NemEladottCukorkak()
        {
            var eladott = _eladasok
                .Select(e => e.Name)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToHashSet();

            return _cukorkak
                .Where(c => !eladott.Contains(c.Name))
                .ToList();
        }

        public double OsszArbevetel() =>
            _eladasok.Sum(e => e.Quantity * e.SalePrice);
    }
}
