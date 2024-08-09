import React, { useState } from "react";
import PostUrl from "../api/post";

const InputField = () => {
  const [url, setUrl] = useState<string>("");

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUrl(event.target.value);
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (url.trim() === "") {
      console.error("URL is required");
      return;
    }
    PostUrl(url);
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
    </>
  );
};

export default InputField;
