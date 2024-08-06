import axios from "axios";

const postData = {
	url: "mymagicurl.net",
};

axios.post("http://localhost:5249/api/ShortLink", postData).then((response) => {
	console.log(response.data);
});
