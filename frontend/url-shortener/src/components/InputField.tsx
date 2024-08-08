import React, { useState } from "react";
import PostUrl from "../api/post";

interface Props {
	postSubmission: () => void;
}

const InputField = ({ postSubmission }: Props) => {
	const [url, setUrl] = useState<string>(""); // Explicitly define type

	// Handle input change
	const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setUrl(event.target.value); // Update the URL state with the input value
	};

	// Handle form submission
	const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
		event.preventDefault(); // Prevent the default form submission behavior
		if (url.trim() === "") {
			// Validate URL to ensure it is not empty
			console.error("URL is required");
			return;
		}
		PostUrl({ url }); // Call PostUrl with the current URL state
		setUrl(""); // Clear the input field after submission
		postSubmission(); // Call postSubmission for any post-submit actions
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
