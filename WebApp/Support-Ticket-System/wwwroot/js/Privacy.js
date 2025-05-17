namespace Support_Ticket_System.wwwroot.js
{
    public class Privacy
    {

        async function fetchPrivateData() {
        const token = localStorage.getItem("jwt_token");
        const response = await fetch('/api/privacy', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });
        const data = await response.text();
        alert(data);
    }

}

