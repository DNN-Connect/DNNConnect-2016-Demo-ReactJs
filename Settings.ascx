<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Connect.DNN.Modules.HitchARide.Settings" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

<fieldset>
 <div class="dnnFormItem">
  <dnn:label id="lblView" runat="server" controlname="ddView" suffix=":" />
  <asp:DropDownList runat="server" ID="ddView" />
 </div>
</fieldset>
