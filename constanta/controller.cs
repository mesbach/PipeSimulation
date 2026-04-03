using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_X.Model;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Water_Flow_Simulation_v1.Pipa;

namespace GDI.constanta
{
    class controller
    {
        private int StatusInsertEdge = 0;
        private List<vertex> node = new List<vertex>();
        private List<Pipa> garis = new List<Pipa>();
        public List<BeanTable> hasilnya;
        private vertex start = new vertex();
        private List<string> hasil2;
        private List<string> hasil;
        private vertex dest = new vertex();
        int earliestMax = 0;
        private Pipa temp = new Pipa();
        private int nama;
        int x, y;
        public void setDest(Point a)
        {
            dest = SelectNode(a);
            try
            {
                MessageBox.Show("berhenti di " + dest.Id);
            }
            catch
            {
                
            }
        }
        public void setStart(Point a)
        {
            start = SelectNode(a);
            try
            {
                MessageBox.Show("start dimulai di " + start.Id);
            }
            catch { }
        }
        public vertex isExistInNode(Point poin)
        {
            foreach (vertex ver in node)
            {
                if (isEqualseInRange(poin, ver))
                    return ver;
            }
            return null;
        }
        public bool isEqualseInRange(Point poin, vertex ver)
        {
            if ((ver.GetCenterPotition().X <= poin.X && ver.GetCenterPotition().X + ver.Size >= poin.X) && (ver.GetCenterPotition().Y <= poin.Y && ver.GetCenterPotition().Y + ver.Size > poin.Y))
                return true;
            else return false;
        }
        public Pipa insertEdge(Point a){
            vertex t = isExistInNode(a);
            if (node.Contains(t)){
                if (StatusInsertEdge == 0){
                    temp.Start = SelectNode(a);
                    StatusInsertEdge = 1;
                }
                else{
                    temp.Destination = SelectNode(a);
                    if (temp.Start == temp.Destination) { StatusInsertEdge = 1; return null; }
                    if (p.PROTOKOL == p.PIPA_ANGSUR_BESAR) insertPipaAngsurBesar(temp);
                    else if (p.PROTOKOL == p.PIPA_ANGSUR_KECIL) insertPipaAngsurKecil(temp);
                    else if (p.PROTOKOL == p.PIPA_BELOK) insertPipaBelok(temp);
                    else if (p.PROTOKOL == p.PIPA_LURUS) insertPipaLurus(temp);
                    else if (p.PROTOKOL == p.PIPA_TIBA_BESAR) insertPembesaranTiba(temp);
                    else if (p.PROTOKOL == p.PIPA_TIBA_KECIL) insertPengecilanTiba(temp);
                    StatusInsertEdge = 0;
                    temp = new Pipa();
                }
            }
            return SelectEdge(a);
            
        }
        public void insertNode(Point b)
        {
            vertex ada = isExistInNode(b);
            if (ada == null)
            {
                vertex baru = new vertex(b);
                baru.Id = nama.ToString();
                nama++;
                baru.ResetWarna();
                node.Add(baru);
            }
            else SelectNode(b);
        }
        public void removeEdge(Point x)
        {
            foreach (Pipa a in garis)
            {
                if (isEqualseInRange(x, a.Start) || isEqualseInRange(x, a.Destination))
                {
                    garis.Remove(a);
                    removeEdge(x);
                    return;
                }
            }
        }
        public void removeNode(Point x)
        {
            removeEdge(x);
            node.Remove(findPointInNode(x));
        }
        public vertex findPointInNode(Point x)
        {
            foreach (vertex a in node)
            {
                if (isEqualseInRange(x, a))
                    return a;
            }
            return new vertex();
        }
        public Pipa SelectEdge(Point poin)
        {
            Pipa temp = new Pipa();
            bool test = false;
            foreach (Pipa e in garis)
            {
                if (e.Center().X -10 <= poin.X && e.Center().X + 10 >= poin.X && e.Center().Y-10 <= poin.Y && e.Center().Y + 10 >= poin.Y)
                {
                    test = true;
                    e.selectWarna();
                    temp = e;
                    break;
                }
                else
                {
                    e.resetWarna();
                }
            }
            if (test)
                return temp;
            else {
                return null;
            }
        }

        
        public vertex SelectNode(Point poin)
        {
            bool test = false;
            vertex select = new vertex();
            foreach (vertex ver in node)
            {
                if (isEqualseInRange(poin, ver))
                {
                    test = true;
                    select = ver;
                    ver.setWarnaSelect();
                }
                else
                    ver.ResetWarna();
            }
            if (test)
                return select;
            else return null;
        }
        internal void drawLine(UIElementCollection canvas)
        {
            foreach (Pipa ed in garis)
                ed.Draw(canvas);
        }
        internal void drawCircle(UIElementCollection canvas)
        {
            foreach (vertex ver in node)
                ver.Draw(canvas);
        }
        private void dfs(vertex nod)
        {
            if (nod.Next == null || nod == dest)
            {
                return;
            }
            foreach (vertex c in nod.Next)
            {
                IEnumerable<Pipa> query = from data in garis
                                          where data.Start == nod && data.Destination == c
                                          select data;
                Pipa ini = query.First();
                ini.ElevasiSebelumnya = ini.Start.ELEVASI;
                ini.compute();
                ini.Destination.ELEVASI = ini.Elevasi;
                isiDataDridView(ini);
                dfs(c);
            }
        }
        private void isiDataDridView(Pipa selectedPipa)
        {
            PipaLurus b = new PipaLurus();
            PipaAngsurBesar c = new PipaAngsurBesar();
            PipaAngsurKecil d = new PipaAngsurKecil();
            PipaBelok f = new PipaBelok();
            PipaPembesaranTibaTiba g = new PipaPembesaranTibaTiba();
            PipaPengecilanTibaTiba h = new PipaPengecilanTibaTiba();

            BeanTable baru = new BeanTable();
            baru.Debit = selectedPipa.Debit.ToString();
            baru.Elevasi = selectedPipa.Elevasi.ToString();
            baru.Kehilangan_Energi = selectedPipa.KehilanganEnergi.ToString();
            if (selectedPipa.GetType() == b.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString();
            }
            else if (selectedPipa.GetType() == c.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString() +" dan "+ ((PipaAngsurBesar)(selectedPipa)).Diameter2.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString() + " dan " + ((PipaAngsurBesar)(selectedPipa)).KecepatanAliran2.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString() + " dan " + ((PipaAngsurBesar)(selectedPipa)).LuasPenampang2;
            }
            else if (selectedPipa.GetType() == d.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString() + " dan " + ((PipaAngsurKecil)(selectedPipa)).Diameter2.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString() + " dan " + ((PipaAngsurKecil)(selectedPipa)).KecepatanAliran2.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString() + " dan " + ((PipaAngsurKecil)(selectedPipa)).LuasPenampang2;
            }
            else if (selectedPipa.GetType() == f.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString();
            }
            else if (selectedPipa.GetType() == g.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString() + " dan " + ((PipaPembesaranTibaTiba)(selectedPipa)).Diameter2.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString() + " dan " + ((PipaPembesaranTibaTiba)(selectedPipa)).KecepatanAliran2.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString() + " dan " + ((PipaPembesaranTibaTiba)(selectedPipa)).LuasPenampang2;
            }
            else if (selectedPipa.GetType() == h.GetType())
            {
                baru.Diameter = selectedPipa.Diameter.ToString() + " dan " + ((PipaPengecilanTibaTiba)(selectedPipa)).Diameter2.ToString();
                baru.Kecepatan_Aliran = selectedPipa.KecepatanAliran.ToString() + " dan " + ((PipaPengecilanTibaTiba)(selectedPipa)).KecepatanAliran2.ToString();
                baru.Luas_Penampang = selectedPipa.LuasPenampang.ToString() + " dan " + ((PipaPengecilanTibaTiba)(selectedPipa)).LuasPenampang2;
            }
            hasilnya.Add(baru);
        }
        public void conput()
        {
            hasilnya = new List<BeanTable>();
            if (start != null && dest != null)
            {
                dfs(start);
            }
            else if (start == null)
                MessageBox.Show("tentukan awalnya");
            else if (dest == null)
                MessageBox.Show("tentukan akhirnya");
        }
        #region insert
        private void insertPipaLurus(Pipa a)
        {
            PipaLurus baru = new PipaLurus();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            
            garis.Add(baru);
        }
        private void insertPipaBelok(Pipa a)
        {
            PipaBelok baru = new PipaBelok();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            garis.Add(baru);
        }
        private void insertPipaAngsurBesar(Pipa a)
        {
            PipaAngsurBesar baru = new PipaAngsurBesar();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            garis.Add(baru);
        }
        private void insertPipaAngsurKecil(Pipa a)
        {
            PipaAngsurKecil baru = new PipaAngsurKecil();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            garis.Add(baru);
        }
        private void insertPembesaranTiba(Pipa a)
        {
            PipaPembesaranTibaTiba baru = new PipaPembesaranTibaTiba();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            garis.Add(baru);
        }
        private void insertPengecilanTiba(Pipa a)
        {
            PipaPengecilanTibaTiba baru = new PipaPengecilanTibaTiba();
            baru.Start = a.Start;
            baru.Destination = a.Destination;

            if (baru.Start.Next == null) baru.Start.Next = new List<vertex>();
            if (baru.Start.Prev == null) baru.Start.Prev = new List<vertex>();
            if (baru.Destination.Next == null) baru.Destination.Next = new List<vertex>();
            if (baru.Destination.Prev == null) baru.Destination.Prev = new List<vertex>();

            baru.Start.Next.Add(baru.Destination);
            baru.Destination.Prev.Add(baru.Start);
            baru.resetWarna();
            garis.Add(baru);
        }
        #endregion
    }
}
