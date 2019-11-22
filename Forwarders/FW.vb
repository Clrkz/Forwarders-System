﻿Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports ADODB
Imports System.IO
Imports System.Data.SqlClient

Module FW
    Public gs_Conn As String = "FILE NAME=" & App_Path() & "\FW.udl"
    Public gs_User As String
    'get all search data from Details Tab
    Public FileNo,
Customer,
Consignee,
SalesPerson,
Description,
ControlNo,
Status,
DateEncoded,
CAS,
ReceivedDate,
ReceivedBy,
ExpirationDate,
ApprovalDate,
ETA,
EDA,
Broker,
SupplierName,
SupplierAddress,
SupplierInfo,
ShippingLine,
Pier,
RegNo,
Vessel,
BillOfLading,
Forwarder1,
Forwarder2,
ContactPerson,
Warehouse,
TelNos,
FAX,
ContainerSize,
ContainerQty,
ContainerDescription,
TotalContainer,
UOM,
ContainerDeposit,
TotalRefund,
PaymentType,
RemoveStatus,
Regular,
Priority,
LackOfDoc,
AirWayBill,
SelfFunded,
LC,
FCL,
LCL,
Manifest,
Telex,
OBL,
LCDate,
LCBank As String

    Public Function App_Path() As String
        App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    End Function


    Public Sub InsertDetails()
        Dim deleteStatus As Integer = 0
        Dim payment, regular, priority, lod, awb, sf, lc, fcl, lcl, manifest, telex, obl As String

        If Details.CheckBox1.Checked Then
            regular = "1"
        Else
            regular = "0"
        End If

        If Details.CheckBox2.Checked Then
            priority = "1"
        Else
            priority = "0"
        End If


        If Details.CheckBox3.Checked Then
            lod = "1"
        Else
            lod = "0"
        End If

        If Details.CheckBox4.Checked Then
            awb = "1"
        Else
            awb = "0"
        End If

        If Details.CheckBox5.Checked Then
            sf = "1"
        Else
            sf = "0"
        End If

        If Details.CheckBox11.Checked Then
            lc = "1"
        Else
            lc = "0"
        End If

        If Details.CheckBox6.Checked Then
            fcl = "1"
        Else
            fcl = "0"
        End If

        If Details.CheckBox7.Checked Then
            lcl = "1"
        Else
            lcl = "0"
        End If

        If Details.CheckBox8.Checked Then
            manifest = "1"
        Else
            manifest = "0"
        End If

        If Details.CheckBox9.Checked Then
            telex = "1"
        Else
            telex = "0"
        End If

        If Details.CheckBox9.Checked Then
            telex = "1"
        Else
            telex = "0"
        End If


        If Details.CheckBox10.Checked Then
            obl = "1"
        Else
            obl = "0"
        End If



        If Details.RadioButton1.Checked Then
            payment = "Cash"
        End If

        If Details.RadioButton2.Checked Then
            payment = "Check"
        End If

        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("INSERT INTO Details (
FileNo,
Customer,
Consignee,
SalesPerson,
Description,
ControlNo,
Status, 
CAS,
ReceivedDate,
ReceivedBy,
ExpirationDate,
ApprovalDate,
ETA,
EDA,
Broker,
SupplierName,
SupplierAddress,
SupplierInfo,
ShippingLine,
Pier,
RegNo,
Vessel,
BillOfLading,
Forwarder1,
Forwarder2,
ContactPerson,
Warehouse,
TelNos,
FAX,
ContainerSize,
ContainerQty,
ContainerDescription,
TotalContainer,
UOM,
ContainerDeposit,
TotalRefund,
PaymentType,
RemoveStatus,
Regular,
Priority,
LackOfDoc,
AirWayBill,
SelfFunded,
LC,
FCL,
LCL,
Manifest,
Telex,
OBL,
LCDate,
LCBank,
DateEncoded
) 
VALUES (
'" & Details.txtFileNo.Text.Trim & "' ,
'" & Details.txtCustomer.Text.Trim & "' , 
'" & Details.txtCosignee.Text.Trim & "' , 
'" & Details.txtSalesPerson.Text.Trim & "' , 
'" & Details.txtDescription.Text.Trim & "' , 
'" & Details.txtCodeNumber.Text.Trim & "' , 
'" & Details.cboStatus.Text & "' ,  
'" & Details.TextBox1.Text.Trim & "' ,
'" & Details.TextBox2.Text.Trim & "' , 
'" & Details.TextBox3.Text.Trim & "' , 
'" & Details.TextBox4.Text.Trim & "' , 
'" & Details.TextBox5.Text.Trim & "' , 
'" & Details.txtETA.Text.Trim & "' , 
'" & Details.txtEDA.Text.Trim & "' , 
'" & Details.txtBroker.Text.Trim & "' , 
'" & Details.TextBox6.Text.Trim & "' , 
'" & Details.TextBox7.Text.Trim & "' , 
'" & Details.TextBox8.Text.Trim & "' , 
'" & Details.TextBox9.Text.Trim & "' , 
'" & Details.TextBox10.Text.Trim & "' , 
'" & Details.TextBox11.Text.Trim & "' , 
'" & Details.txtVessel.Text.Trim & "' , 
'" & Details.TextBox19.Text.Trim & "' , 
'" & Details.TextBox14.Text.Trim & "' , 
'" & Details.TextBox15.Text.Trim & "' , 
'" & Details.TextBox16.Text.Trim & "' , 
'" & Details.TextBox17.Text.Trim & "' , 
'" & Details.TextBox18.Text.Trim & "' , 
'" & Details.TextBox20.Text.Trim & "' , 
'" & Details.TextBox21.Text.Trim & "' , 
'" & Details.TextBox22.Text.Trim & "' , 
'" & Details.TextBox23.Text.Trim & "' , 
'" & Details.TextBox24.Text.Trim & "' , 
'" & Details.TextBox25.Text.Trim & "' , 
'" & Details.TextBox26.Text.Trim & "' , 
'" & Details.TextBox27.Text.Trim & "' , 
'" & payment & "' , 
'" & deleteStatus & "' , 
'" & regular & "', 
'" & priority & "', 
'" & lod & "', 
'" & awb & "', 
'" & sf & "', 
'" & lc & "', 
'" & fcl & "', 
'" & lcl & "', 
'" & manifest & "', 
'" & telex & "', 
'" & obl & "', 
'" & Details.TextBox13.Text.Trim & "', 
'" & Details.TextBox12.Text.Trim & "' ,
CURRENT_TIMESTAMP
)", mdl.conn)
        mdl.adapter.Fill(mdl.ds, "Details")
        Details.ClearDetails()
        MessageBox.Show("Customer information successfully added.")
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        rs.Open("Select FileNo,Customer  From Details Where FileNo LIKE '%" + valueToSearch.Trim + "%'", gs_Conn, 2)

        DataAdapter.Fill(Dataset, rs, "Details")
        Details.DataGridView1.DataSource = Dataset.Tables(0)
        Details.DataGridView1.ReadOnly = True
        Details.DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Details.DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Public Sub GetAllDataDetails(valueToSearch As String)
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        rs.Open("Select FileNo,
Customer,
Consignee,
SalesPerson,
Description,
ControlNo,
Status, 
DateEncoded,
CAS,
ReceivedDate,
ReceivedBy,
ExpirationDate,
ApprovalDate,
ETA,
EDA,
Broker,
SupplierName,
SupplierAddress,
SupplierInfo,
ShippingLine,
Pier,
RegNo,
Vessel,
BillOfLading,
Forwarder1,
Forwarder2,
ContactPerson,
Warehouse,
TelNos,
FAX,
ContainerSize,
ContainerQty,
ContainerDescription,
TotalContainer,
UOM,
ContainerDeposit,
TotalRefund,
PaymentType,
RemoveStatus,
Regular,
Priority,
LackOfDoc,
AirWayBill,
SelfFunded,
LC,
FCL,
LCL,
Manifest,
Telex,
OBL,
LCDate,
LCBank  From Details Where FileNo = '" + valueToSearch.Trim + "'", gs_Conn, 2)
        If rs.RecordCount = 0 Then
            MessageBox.Show("No record")
        Else
            FileNo = rs.Fields(0).Value.ToString
            Customer = rs.Fields(1).Value.ToString
            Consignee = rs.Fields(2).Value.ToString
            SalesPerson = rs.Fields(3).Value.ToString
            Description = rs.Fields(4).Value.ToString
            ControlNo = rs.Fields(5).Value.ToString
            Status = rs.Fields(6).Value.ToString
            DateEncoded = rs.Fields(7).Value.ToString
            CAS = rs.Fields(8).Value.ToString
            ReceivedDate = rs.Fields(9).Value.ToString
            ReceivedBy = rs.Fields(10).Value.ToString
            ExpirationDate = rs.Fields(11).Value.ToString
            ApprovalDate = rs.Fields(12).Value.ToString
            ETA = rs.Fields(13).Value.ToString
            EDA = rs.Fields(14).Value.ToString
            Broker = rs.Fields(15).Value.ToString
            SupplierName = rs.Fields(16).Value.ToString
            SupplierAddress = rs.Fields(17).Value.ToString
            SupplierInfo = rs.Fields(18).Value.ToString
            ShippingLine = rs.Fields(19).Value.ToString
            Pier = rs.Fields(20).Value.ToString
            RegNo = rs.Fields(21).Value.ToString
            Vessel = rs.Fields(22).Value.ToString
            BillOfLading = rs.Fields(23).Value.ToString
            Forwarder1 = rs.Fields(24).Value.ToString
            Forwarder2 = rs.Fields(25).Value.ToString
            ContactPerson = rs.Fields(26).Value.ToString
            Warehouse = rs.Fields(27).Value.ToString
            TelNos = rs.Fields(28).Value.ToString
            FAX = rs.Fields(29).Value.ToString
            ContainerSize = rs.Fields(30).Value.ToString
            ContainerQty = rs.Fields(31).Value.ToString
            ContainerDescription = rs.Fields(32).Value.ToString
            TotalContainer = rs.Fields(33).Value.ToString
            UOM = rs.Fields(34).Value.ToString
            ContainerDeposit = rs.Fields(35).Value.ToString
            TotalRefund = rs.Fields(36).Value.ToString
            PaymentType = rs.Fields(37).Value.ToString
            RemoveStatus = rs.Fields(38).Value.ToString
            Regular = rs.Fields(39).Value.ToString
            Priority = rs.Fields(40).Value.ToString
            LackOfDoc = rs.Fields(41).Value.ToString
            AirWayBill = rs.Fields(42).Value.ToString
            SelfFunded = rs.Fields(43).Value.ToString
            LC = rs.Fields(44).Value.ToString
            FCL = rs.Fields(45).Value.ToString
            LCL = rs.Fields(46).Value.ToString
            Manifest = rs.Fields(47).Value.ToString
            Telex = rs.Fields(48).Value.ToString
            OBL = rs.Fields(49).Value.ToString
            LCDate = rs.Fields(50).Value.ToString
            LCBank = rs.Fields(51).Value.ToString




            '  MessageBox.Show(Customer)
            DataAdapter.Fill(Dataset, rs, "Details")
        End If
        '   'Details.DataGridView1.DataSource = Dataset.Tables(0)
        '    Details.DataGridView1.ReadOnly = True
        '   Details.DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ''    Details.DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        ' Details.txtCosignee.Text = CStr(rs.Rows(2)("Consignee"))
        ' Details.txtCosignee.DataBindings.Add("Text", rs, "Consignee")
        'Details.txtCosignee.Text = CStr(rs.Rows(0)("Consignee"))
    End Sub



End Module