import React, { useState } from "react";
import PostUrl from "../api/post";

interface ShortLinkDto {
  id: string;
  short_link: string;
  full_link: string;
}

const InputField: React.FC = () => {
  const [url, setUrl] = useState<string>("");
  const [response, setResponse] = useState<ShortLinkDto | null>(null);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUrl(event.target.value);
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (url.trim() === "") {
      console.error("URL is required");
      return;
    }

    const apiResponse = await PostUrl(url);

    if (apiResponse) {
      setResponse(apiResponse);
    } else {
      setResponse(null);
    }

    setUrl("");
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={url}
          onChange={handleInputChange}
          placeholder="Enter a URL to shortify..."
        />
        <button type="submit">Submit</button>
      </form>

      {response ? (
        <>
          {console.log("Short link: " + response.short_link)}
          {console.log("Full link: " + response.full_link)}
          <h2>The short URL: {response.short_link}</h2>
          <h2>The Original URL: {response.full_link}</h2>
        </>
      ) : (
        <h2>{response === null ? "Invalid post" : "No response yet"}</h2>
      )}
    </>
  );
};

export default InputField;
