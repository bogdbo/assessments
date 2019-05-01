export function callApi<T>(url: string, opt?: RequestInit): Promise<T> {
  return fetch(url, opt)
    .then(response => {
      if (!response.ok) {
        throw new Error(response.statusText)
      }
      return response.json() as Promise<T>;
    });
}
