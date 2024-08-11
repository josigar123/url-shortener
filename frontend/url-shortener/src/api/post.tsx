import axios from "axios";

interface ShortLinkDto {
  id: string;
  short_link: string;
  full_link: string;
}

const PostUrl = async (url: string): Promise<ShortLinkDto | null> => {
  const BASE_URL = "http://localhost:5249/api/ShortLink/";

  try {
    const response: ShortLinkDto = await axios.post(BASE_URL, url, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    console.log("URL successfully submitted:", response);
    return response;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error(
        "Error posting URL:",
        error.response?.data || error.message
      );
      return null;
    } else {
      console.error("An unexpected error occurred:", error);
      return null;
    }
  }
};

export default PostUrl;
