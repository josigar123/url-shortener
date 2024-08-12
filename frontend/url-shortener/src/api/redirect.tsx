import axios from "axios";

const Redirect = async (short_link: string) => {
  const BASE_URL = "http://localhost:5249/api/ShortLink/";
  const url = `${BASE_URL}${short_link}`;

  try {
    const response = await axios.get(url);

    console.log("Data successfully retrieved: ", response.data);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error(
        "Error getting URL:",
        error.response?.data || error.message
      );
    } else {
      console.error("An unexpected error occurred:", error);
    }
  }

  return null;
};

export default Redirect;
