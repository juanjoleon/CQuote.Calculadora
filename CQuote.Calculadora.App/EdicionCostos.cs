using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class EdicionCostos : Form
    {
        public EdicionCostos()
        {
            InitializeComponent();
        }

        public void CargarMateriales(List<(string Tipo, ConfigMaterial Material)> materiales)
        {
            DtvDetalle.Columns.Clear();
            DtvDetalle.Rows.Clear();
            DtvDetalle.Columns.Add("Tipo", "Tipo");
            DtvDetalle.Columns.Add("Num", "Num");
            DtvDetalle.Columns.Add("Descripcion", "Descripción");
            DtvDetalle.Columns.Add("CostoProveedor", "Costo Proveedor");
            DtvDetalle.Columns.Add("CostoImportacion", "Costo Importación");
            DtvDetalle.Columns.Add("Factor1", "Factor1");
            DtvDetalle.Columns.Add("Calculo1", "Cálculo1");
            DtvDetalle.Columns.Add("Factor2", "Factor2");
            DtvDetalle.Columns.Add("Calculo2", "Cálculo2");
            DtvDetalle.Columns.Add("Factor3", "Factor3");
            DtvDetalle.Columns.Add("Calculo3", "Cálculo3");
            DtvDetalle.Columns.Add("CostoLamina", "Costo Lámina");
            DtvDetalle.Columns.Add("Desperdicio", "Desperdicio");
            DtvDetalle.Columns.Add("CostoCorte", "Costo Corte");
            DtvDetalle.Columns.Add("CostoProcesoTermico", "Costo Proceso Térmico");
            DtvDetalle.Columns.Add("Total", "Total con Proceso Térmico");

            foreach (var (tipo, mat) in materiales)
            {
                decimal calculo1 = 0, calculo2 = 0, calculo3 = 0, costoLamina = 0, costoCorte = 0, costoProcesoTermico = 0, total = 0;
                if (tipo == "Cristal")
                {
                    calculo1 = (mat.CostoProveedor + mat.CostoImportacion) / (mat.Factor1 == 0 ? 1 : mat.Factor1);
                    calculo2 = calculo1 / (mat.Factor2 == 0 ? 1 : mat.Factor2);
                    calculo3 = calculo2 * mat.Factor3;
                    costoLamina = calculo3 * 1.01m; // merma fija
                    costoCorte = mat.CostoProcesoCorte;
                    costoProcesoTermico = 10; // fijo
                    total = costoLamina + costoCorte + costoProcesoTermico;
                }
                else
                {
                    calculo1 = (mat.CostoProveedor + mat.CostoImportacion) / (mat.Factor1 == 0 ? 1 : mat.Factor1);
                    calculo2 = calculo1 / (mat.Factor2 == 0 ? 1 : mat.Factor2);
                    calculo3 = calculo2 * mat.Factor3;
                    costoLamina = calculo3;
                    costoCorte = 0;
                    costoProcesoTermico = 0;
                    total = costoLamina;
                }
                DtvDetalle.Rows.Add(
                    tipo,
                    mat.Num,
                    mat.Descripcion,
                    mat.CostoProveedor,
                    mat.CostoImportacion,
                    mat.Factor1,
                    calculo1,
                    mat.Factor2,
                    calculo2,
                    mat.Factor3,
                    calculo3,
                    costoLamina,
                    mat.Desperdicio,
                    costoCorte,
                    costoProcesoTermico,
                    total
                );
            }
        }
    }
}
