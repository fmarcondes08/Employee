import type { Employee } from "../types/employee";
import { API_URL, API_TOKEN } from "../config/env";

async function request<T>(path: string, init?: RequestInit): Promise<T> {
  const res = await fetch(`${API_URL}${path}`, {
    ...init,
    headers: {
      "Content-Type": "application/json",
      "X-Auth-Token": API_TOKEN,
      ...(init?.headers || {}),
    },
  });

  if (!res.ok) {
    let message = `${res.status} ${res.statusText}`;
    try {
      const data = await res.json();
      message = data?.error || JSON.stringify(data);
    } catch { /* ignore */ }
    throw new Error(message);
  }
  return res.status === 204 ? (undefined as T) : await res.json();
}

export const EmployeesApi = {
  list: () => request<Employee[]>("/employees"),
  get: (id: number) => request<Employee>(`/employees/${id}`),
  create: (payload: Employee) =>
    request<Employee>("/employees", {
      method: "POST",
      body: JSON.stringify(payload),
    }),
  update: (payload: Employee) =>
    request<Employee>(`/employees/`, {
      method: "PUT",
      body: JSON.stringify(payload),
    }),
  remove: (id: number) =>
    request<void>(`/employees/${id}`, { method: "DELETE" }),
};