' Name:         Utilities Project
' Purpose:      Display utility bills.
' Programmer:   <your name> on <current date>

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Private Sub BillsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles BillsBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.BillsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.UtilitiesDataSet)
            MessageBox.Show("Changes saved.", "Utility bills",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Utility bills",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'UtilitiesDataSet.Bills' table. You can move, or remove it, as needed.
        Me.BillsTableAdapter.Fill(Me.UtilitiesDataSet.Bills)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click

        'declare variables
        Dim decElcTt As Decimal
        Dim decWtTt As Decimal
        Dim decGsTt As Decimal
        Dim decUtlTt As Decimal

        'determine totals for each row using For Each loop
        For Each row As UtilitiesDataSet.BillsRow In UtilitiesDataSet.Bills.Rows
            decElcTt += row.Electricity
            decWtTt += row.Water
            decGsTt += row.Gas
        Next
        decUtlTt = decElcTt + decWtTt + decGsTt

        'display totals in lables 
        lblElecTtl.Text = decElcTt.ToString("C2")
        lblGsTt.Text = decGsTt.ToString("C2")
        lblWtTtl.Text = decWtTt.ToString("C2")

        lblUtTt.Text = decUtlTt.ToString("C2")

    End Sub

End Class
