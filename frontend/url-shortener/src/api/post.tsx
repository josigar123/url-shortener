import axios from "axios";

const PostUrl = async (url: string) => {
  try {
    const response = await axios.post(
      "http://localhost:5249/api/ShortLink",
      url,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
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
