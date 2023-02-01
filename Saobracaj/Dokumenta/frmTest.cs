using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace Saobracaj.Dokumenta
{
    public partial class frmTest : Form
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        GMapControl map = new GMapControl();
        GMapOverlay overlay = new GMapOverlay("marker");
        GMapOverlay routes = new GMapOverlay("routes");
        Label pom1 = new Label();
        string opis;
        double lat;
        double lng;
        ComboBox combo_Najave = new ComboBox();
        public frmTest()
        {
            InitializeComponent();

        }
        private void frmTest_Load(object sender, EventArgs e)
        {
            GMapProviders.BingMap.ClientKey = @"AtxaZgP7EcuvsgnpVDOkWvq67eUUNIiCR2bUnygPkeUusm7STHdTneUwWVc7xVyo";
            LoadMap();
            FillCombo();
            SveNajave();
        }
        
        private void LoadMap()
        {
            map.MapProvider = GMapProviders.BingMap;
            map.Position = new PointLatLng(44.65486, 20.20017);
            map.MinZoom = 3;
            map.MaxZoom = 20;
            map.Zoom = 8;
            map.DragButton = MouseButtons.Left;
            map.Dock = DockStyle.Fill;
            map.ShowCenter = false;
            this.Controls.Add(map);
        }
        private void FillCombo()
        {
            var queryStanice = "select distinct Najava.Granicna,RTrim(Stanice.Opis) as Opis " +
                "from Najava inner join stanice on Stanice.id=Najava.Granicna  " +
                "where Status <>7 and Status <>9 and Longitude <>0 and latitude <>0";
            var conn = new SqlConnection(connect);
            var adapterStanice = new SqlDataAdapter(queryStanice, conn);
            var setStanice = new DataSet();
            adapterStanice.Fill(setStanice);
            combo_Stanice.DataSource = setStanice.Tables[0];
            combo_Stanice.DisplayMember = "Opis";
            combo_Stanice.ValueMember = "Granicna";

            var queryNajava = "select ID,RTrim(PrevozniPut) as PrevozniPut from Najava Where Status<>7 and Status<>9 order by ID desc";
            var adapterNajava = new SqlDataAdapter(queryNajava, conn);
            var setNajava = new DataSet();
            adapterNajava.Fill(setNajava);
            //combo_Najave.DataSource = setNajava.Tables[0];
            //combo_Najave.DisplayMember = "PrevozniPut";
           // combo_Najave.ValueMember = "ID";
        }
        private void SveNajave()
        {
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            var query = "select distinct Najava.Granicna as Granicna,Stanice.Opis as Opis,Stanice.Longitude,Stanice.Latitude,Sum(BrojKola) as BrojKola , Sum(Tezina) as Tezina," +
                "Sum(NetoTezinaM) as NetoTezinaM " +
                "from Najava " +
                "inner join stanice on Stanice.id=Najava.Granicna " +
                "where Status <>7 and Status <>9 and Longitude <>0 and latitude <>0 " +
                "group by Najava.Granicna,Stanice.Opis,Stanice.Longitude,Stanice.Latitude";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            
            int brKola;
            double tezina;
            double neto;
            int id=0;
            int count=dr.FieldCount;
            while (dr.Read())
            {
                id = Convert.ToInt32(dr["Granicna"]);
                opis = dr["Opis"].ToString().TrimEnd();
                lat = Convert.ToDouble(dr["Latitude"].ToString());
                lng = Convert.ToDouble(dr["Longitude"].ToString());
                brKola = Convert.ToInt32(dr["BrojKola"].ToString());
                tezina = Convert.ToDouble(dr["Tezina"].ToString());
                neto = Convert.ToDouble(dr["NetoTezinaM"].ToString());
                string text = opis+"\nBroj Kola: " + brKola.ToString() + "\nTezina: " + tezina.ToString() + "\nNeto: " + neto.ToString();
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lng, lat), GMarkerGoogleType.red_pushpin);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = text;
                overlay.Markers.Add(marker);
                map.Overlays.Add(overlay);
                
            }
            //combo_Stanice.Text = opis;
            conn.Close();
            map.OnMarkerClick += new MarkerClick(map_OnMarkerClick);
        }
        void map_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            overlay.Clear();
            routes.Clear();

            marker.ToolTipMode = MarkerTooltipMode.Always;
            
            overlay.Markers.Add(marker);
            map.Overlays.Add(overlay);

            List<PointLatLng> points = new List<PointLatLng>();
            SqlConnection conn = new SqlConnection(connect);
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            conn.Open();
            var query = "select  najava.ID as ID,Najava.uputna as Uputna,stanice.Opis as Opis,stanice.Longitude as Longitude," +
                "stanice.Latitude as Latitude,Najava.Status as Status " +
                "from Najava inner join stanice on stanice.ID=Najava.Uputna " +
                "Where Najava.Granicna=327 and Najava.Status<>7 and Najava.Status<>9 and stanice.Longitude<>0 and stanice.Latitude<>0";
            SqlCommand cmd = new SqlCommand(query, conn);
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            SqlDataReader dr = cmd.ExecuteReader();
            string stanica;
            double latDo;
            double lngDo;
            int status;
            while (dr.Read())
            {
                stanica = dr["Opis"].ToString().TrimEnd();
                latDo = Convert.ToDouble(dr["Latitude"].ToString());
                lngDo = Convert.ToDouble(dr["Longitude"].ToString());
                status = Convert.ToInt32(dr["Status"].ToString());

                GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(lngDo, latDo), GMarkerGoogleType.blue_dot);
                marker2.ToolTipMode = MarkerTooltipMode.Always;
                marker2.ToolTipText = stanica;

                polygon.Stroke.Width = 3;
                if (status == 1) { polygon.Stroke.Color = Color.Red; }
                else if (status == 2) { polygon.Stroke.Color = Color.Blue; }
                else if (status == 3) { polygon.Stroke.Color = Color.Green; }
                else if (status == 4) { polygon.Stroke.Color = Color.Yellow; }
                else if (status == 5) { polygon.Stroke.Color = Color.Black; }
                else if (status == 6) { polygon.Stroke.Color = Color.White; }
                else if (status == 8) { polygon.Stroke.Color = Color.Gray; }
                else { polygon.Stroke.Color = Color.RosyBrown; }

                points.Add(new PointLatLng(lng, lat));
                points.Add(new PointLatLng(lngDo, latDo));
                polyOverlay.Polygons.Add(polygon);
            }
            conn.Close();
            map.Overlays.Add(polyOverlay);
            //combo_Stanice.Text = opis;

            /*
            double latDo;
            double lngDo;
            int status;
            string opisDo;
            conn.Open();
            var query2 = "select  najava.ID as ID,Najava.uputna as Uputna,stanice.Opis as Opis,stanice.Longitude as Longitude," +
                "stanice.Latitude as Latitude,Najava.Status as Status " +
                "from Najava " +
                "inner join stanice on stanice.ID=Najava.Uputna " +
                "Where Najava.Granicna=" + id + " and Najava.Status<>7 and Najava.Status<>9 and stanice.Longitude<>0 and stanice.Latitude<>0";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                opisDo = dr2["Opis"].ToString();
                latDo = Convert.ToDouble(dr2["Latitude"].ToString());
                lngDo = Convert.ToDouble(dr2["Longitude"].ToString());
                status = Convert.ToInt32(dr2["Status"].ToString());
                GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(lngDo, latDo), GMarkerGoogleType.blue_dot);
                marker2.ToolTipMode = MarkerTooltipMode.Always;
                marker2.ToolTipText = "Uputna: " + opisDo;
                

                if (lat == 0) { lat = 43.569355; }
                if (lng == 0) { lng = 20.243095; }
                if (latDo == 0) { latDo = 46.0972205; }
                if (lngDo == 0) { lngDo = 20.2241772; }

                polygon.Stroke.Width = 5;
                if (status == 1) { polygon.Stroke.Color = Color.Red; }
                else if (status == 2) { polygon.Stroke.Color = Color.Blue; }
                else if (status == 3) { polygon.Stroke.Color = Color.Green; }
                else if (status == 4) { polygon.Stroke.Color = Color.Yellow; }
                else if (status == 5) { polygon.Stroke.Color = Color.Black; }
                else if (status == 6) { polygon.Stroke.Color = Color.White; }
                else if (status == 8) { polygon.Stroke.Color = Color.Gray; }
                else { polygon.Stroke.Color = Color.RosyBrown; }

                points.Add(new PointLatLng(lng, lat));
                points.Add(new PointLatLng(lngDo, latDo));
               
                overlay.Markers.Add(marker2);
            }
            conn.Close();
            polyOverlay.Polygons.Add(polygon);
            map.Overlays.Add(polyOverlay);
            map.Overlays.Add(overlay);
            */
        }
        private void Stanice()
        {
            SqlConnection conn = new SqlConnection(connect);


        }
        private void btn_Stanica_Click(object sender, EventArgs e)
        {
            map.Refresh();
            SveNajave();
        }
        private void nadjiTrasu()
        {
            overlay.Clear();
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            int Od=0;
            int Do=0;
            int status=0;
            var query = "Select * From Najava Where ID= " + combo_Najave.SelectedValue;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Od = Convert.ToInt32(dr["Otpravna"].ToString());
                Do = Convert.ToInt32(dr["Uputna"].ToString());
                status = Convert.ToInt32(dr["Status"].ToString());
            }
            conn.Close();

            var query2 = "Select Opis,Longitude,Latitude From Stanice Where ID= " + Od.ToString();
            string od = "";
            double lngOD=0;
            double latOD=0;
            conn.Open();
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lngOD = Convert.ToDouble(dr2["Longitude"].ToString());
                latOD = Convert.ToDouble(dr2["Latitude"].ToString());
                od = dr2["Opis"].ToString();
            }
            if (lngOD == 0) { lngOD =  20.243095; }
            if (latOD == 0) { latOD = 43.569355; }
            conn.Close();


            var query3 = "Select Opis,Longitude,Latitude From Stanice Where ID= " + Do.ToString();
            string doo = "";
            double lngDO = 0;

            double latDO = 0;
            conn.Open();
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                lngDO = Convert.ToDouble(dr3["Longitude"].ToString());
                latDO = Convert.ToDouble(dr3["Latitude"].ToString());
                doo = dr3["Opis"].ToString();
            }
            if (lngDO == 0) { lngDO = 20.243095; }
            if (latDO == 0) { latDO = 43.569355; }
            conn.Close();

            GMapProviders.BingMap.ClientKey = @"vYzQBrYv7RcjJQFw7tPm~xouelNoiO9OfAnm3N3Crww~Ar2-Rl3OhJCb2JzOGmnKSuQPeX9cZ8X2CMF9rvGYol0A2fufTETcMEtA5bPY7VNk";
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(lngOD, latOD), GMarkerGoogleType.green_dot);
            overlay.Markers.Add(marker2);
            marker2.ToolTipMode = MarkerTooltipMode.Always;
            marker2.ToolTipText = "Otpravna: " + od;

            GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(lngDO, latDO), GMarkerGoogleType.blue_dot);
            overlay.Markers.Add(marker3);
            marker3.ToolTipMode = MarkerTooltipMode.Always;
            marker3.ToolTipText = "Uputna: " + doo;

            //var route = BingMapProvider.Instance.GetRoute(new PointLatLng(lngOD, latOD), new PointLatLng(lngDO, latDO), true, false, 8);
            //var r = new GMapRoute(route.Points, "route");

            // r.Stroke.Width = 5;
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(lngOD, latOD));
            points.Add(new PointLatLng(lngDO, latDO));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");

            polygon.Stroke.Width = 3;
            if (status == 1) { polygon.Stroke.Color = Color.Red; }
            else if (status == 2) { polygon.Stroke.Color = Color.Blue; }
            else if (status == 3) { polygon.Stroke.Color = Color.Green; }
            else if (status == 4) { polygon.Stroke.Color = Color.Yellow; }
            else if (status == 5) { polygon.Stroke.Color = Color.Black; }
            else if (status == 6) { polygon.Stroke.Color = Color.White; }
            else if (status == 8) { polygon.Stroke.Color = Color.Gray; }
            else { polygon.Stroke.Color = Color.RosyBrown; }
            
            //routes.Routes.Add(r);
            //map.Overlays.Add(routes);
            polyOverlay.Polygons.Add(polygon);
            map.Overlays.Add(polyOverlay);
            map.Overlays.Add(overlay);


            map.Zoom = 7;
            map.Zoom = 8;
        }

        private void btn_Najave_Click(object sender, EventArgs e)
        {
            nadjiTrasu();
        }
        private void combo_Stanice_TextChanged(object sender, EventArgs e)
        {
           // overlay.Clear();
        }

        private void combo_Najave_TextChanged(object sender, EventArgs e)
        {
            //overlay.Clear();
            //routes.Clear();
        }

        private void btn_ZoomIN_Click(object sender, EventArgs e)
        {
            map.Zoom++;
        }

        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            map.Zoom--;
        }
    }
}
