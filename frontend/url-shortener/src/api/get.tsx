import axios from "axios";

interface ShortLinkDto {
  id: string;
  short_link: string;
  full_link: string;
}

const GetData = async (id: string): Promise<ShortLinkDto | null> => {
  const BASE_URL = "http://localhost:5249/api/ShortLink/";
  const url = `${BASE_URL}${id}`;

  try {
    const response = await axios.get<ShortLinkDto>(url);

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

export default GetData;
