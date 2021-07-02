<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Veterinaria.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row ml-auto mr-auto">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Acciones Registradas</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="accion" HeaderText="accion" SortExpression="accion" />
                                <asp:BoundField DataField="usuario" HeaderText="usuario" SortExpression="usuario" />
                                <asp:BoundField DataField="created_at" HeaderText="created_at" SortExpression="created_at" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_a7554f_veterinariaConnectionString %>" SelectCommand="SELECT * FROM [Bitacora] ORDER BY [created_at] DESC"></asp:SqlDataSource>
                        <%--<table id="tbl_pacientes" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Accion</th>
                                    <th>Usuario</th>
                                    <th>Fecha</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_pacientes_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>--%>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
