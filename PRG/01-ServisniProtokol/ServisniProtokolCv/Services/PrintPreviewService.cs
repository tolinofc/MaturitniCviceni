using ServisniProtokolCv.Interfaces;
using ServisniProtokolCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisniProtokolCv.Services
{
    public class PrintPreviewService : IDrawable
    {
        private Protocol protocol;
        public PrintPreviewService(Protocol protocol)
        {
            this.protocol = protocol;
        }

        public void Draw(Graphics g, int width, int height)
        {
            int hMid = height / 2;
            int wMid = width / 2;

            Font h1 = new Font("Arial", 16, FontStyle.Bold);
            Font h2 = new Font("Arial", 12);
            Font normal = new Font("Arial", 10);

            // border
            g.DrawRectangle(Pens.Black, 10, 10, width - 20, height - 20);

            #region header

            // title
            string title = "Potvrzení o provedení měření";
            SizeF titleSize = g.MeasureString(title, h1);
            PointF titlePoint = new PointF(wMid - titleSize.Width / 2, 30);

            g.DrawString(title, h1, Brushes.Black, titlePoint);

            // measure date
            PointF measureDatePoint = new PointF(20, titlePoint.Y + 30);
            g.DrawString($"Datum měření: {protocol.MeasureDate.ToShortDateString()}", normal, Brushes.Black, measureDatePoint);

            // protocol number
            PointF protocolNumberPoint = new PointF(width - 200, measureDatePoint.Y);
            g.DrawString($"Číslo protokolu: {protocol.ProtocolNumber}", normal, Brushes.Black, protocolNumberPoint);

            #endregion

            #region customer

            g.DrawRectangle(Pens.Black, 20, measureDatePoint.Y + 20, wMid - 20, 125);

            //header
            PointF customerHeaderPoint = new PointF(30, measureDatePoint.Y + 40);
            g.DrawString($"Zákazník", h2, Brushes.Black, customerHeaderPoint);

            StringBuilder customerString = new StringBuilder();

            customerString.AppendLine($"Název: {protocol.Customer.Name}");
            customerString.AppendLine($"Adresa: {protocol.Customer.Address}");
            customerString.AppendLine($"PSČ: {protocol.Customer.PostalCode}");
            customerString.AppendLine($"IČ: {protocol.Customer.ICO}");

            PointF customerTextPoint = new PointF(customerHeaderPoint.X, customerHeaderPoint.Y + 25);
            g.DrawString(customerString.ToString(), normal, Brushes.Black, customerTextPoint);

            #endregion

            #region device

            g.DrawRectangle(Pens.Black, wMid + 20, measureDatePoint.Y + 20, wMid - 40, 125);

            //header
            PointF deviceHeaderPoint = new PointF(wMid + 30, customerHeaderPoint.Y);
            g.DrawString($"Zařízení", h2, Brushes.Black, deviceHeaderPoint);

            StringBuilder deviceString = new StringBuilder();

            deviceString.AppendLine($"Výrobce: {protocol.Device.Manufacturer}");
            deviceString.AppendLine($"Model: {protocol.Device.Model}");
            deviceString.AppendLine($"Sériové číslo: {protocol.Device.SerialNumber}");

            PointF deviceTextPoint = new PointF(deviceHeaderPoint.X, deviceHeaderPoint.Y + 25);
            g.DrawString(deviceString.ToString(), normal, Brushes.Black, deviceTextPoint);

            #endregion

            #region measure

            // header
            PointF measureHeaderPoint = new PointF(20, deviceTextPoint.Y + 125);
            g.DrawString("Měření", h2, Brushes.Black, measureHeaderPoint);

            // th parameter
            PointF thParameterPoint = new PointF(20, measureHeaderPoint.Y + 30);
            g.DrawString("Parametr", h2, Brushes.Black, thParameterPoint);

            // th measured value
            string thMeasuredValue = "Naměřená hodnota";
            SizeF thMeasuredValueSize = g.MeasureString(thMeasuredValue, h2);
            PointF thMeasuredValuePoint = new PointF(wMid - thMeasuredValueSize.Width / 2, thParameterPoint.Y);
            g.DrawString(thMeasuredValue, h2, Brushes.Black, thMeasuredValuePoint);

            // th is optimal
            PointF thIsOptimalPoint = new PointF(width - 150, thParameterPoint.Y);
            g.DrawString("Vyhovuje", h2, Brushes.Black, thIsOptimalPoint);

            // td measures
            float measureY = thParameterPoint.Y + 30;
            for (int i = 0; i < protocol.MeasureList.Count; i++)
            {
                g.DrawString(protocol.MeasureList[i].Parameter, normal, Brushes.Black, thParameterPoint.X, measureY);

                g.DrawString(protocol.MeasureList[i].MeasuredValue + protocol.MeasureList[i].Unit, normal, Brushes.Black, wMid - 25, measureY);

                g.DrawString(protocol.MeasureList[i].IsOptimal ? "Ano" : "Ne", normal, Brushes.Black, thIsOptimalPoint.X + 25, measureY);

                measureY += 20;
            }

            #endregion

            SizeF resultSize = g.MeasureString(protocol.GetResult(), h1);
            PointF resultPoint = new PointF(wMid - resultSize.Width / 2, measureY + 50);
            g.DrawString(protocol.GetResult(), h1, Brushes.Black, resultPoint);
        }
    }
}
