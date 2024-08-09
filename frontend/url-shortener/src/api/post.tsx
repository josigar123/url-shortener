import axios from "axios";

const PostUrl = async (url: string) => {
  const BASE_URL = "http://localhost:5249/api/ShortLink/";

  try {
    const response = await axios.post(BASE_URL, url, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    console.log("URL successfully submitted:", response.data);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error(
        "Error posting URL:",
        error.response?.data || error.message
      );
    } else {
      console.error("An unexpected error occurred:", error);
    }
  }
};

export default PostUrl;
