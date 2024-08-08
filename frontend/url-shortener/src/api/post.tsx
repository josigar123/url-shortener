import axios from "axios";

interface PostData {
	url: string;
}

const PostUrl = ({ url }: PostData) => {
	axios
		.post("http://localhost:5249/api/ShortLink", { url })
		.then((response) => {
			console.log("URL successfully submitted:", response.data);
		})
		.catch((error) => {
			console.error("Error posting URL:", error.response.data);
		});
};

export default PostUrl;
