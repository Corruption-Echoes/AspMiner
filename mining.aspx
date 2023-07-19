<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mining.aspx.cs" Inherits="idleMiner.mining" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="oreDisplay" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="minerDisplay" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="debugDisplay" runat="server" Text=""></asp:Label>
            <asp:Button ID="Mine" runat="server" Text="Dig" Onclick="ManualMine"/>
            <asp:Button ID="JavaMine" hidden="hidden" runat="server" Text="Dig" OnClick="AutoMine"/>
            <asp:Button ID="Purchase" runat="server" Text="Buy Miner" OnClick="PurchaseMiner"/>
            <br />
            <progress id="automineTimer" value="0" max="100" runat="server"></progress>
            <input id="timerPort" runat="server" hidden="hidden"></input>
        </div>
        <script>
            const delay = 1000
            const chunkCount=100
            //Enable auto mining
             var intervalID = setInterval(updatetimer, delay / chunkCount)
            
            function updatetimer() {
                var progress = document.getElementById("automineTimer")
                var port=document.getElementById("timerPort")
                progress.value = 100 / chunkCount + progress.value
                port.value = progress.value
                console.log("updateTimer triggered")
                if (progress.value >= 100) {
                    document.getElementById("JavaMine").click()
                    clearInterval(intervalID)
                }
            }
        </script>
    </form>
</body>
</html>
